using TMPro;
using UnityEngine;
using System.Collections;
using System;
using CharacterSystem;
using System.Reflection;
using System.ComponentModel;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    // Textfields
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text TimerText;

    // Enemy data
    [SerializeField] Vector2[] EnemySpawnCoordinates;
    [SerializeField] GameObject[] Enemies;
    [SerializeField] float EnemyRespawnTime;

    // Globals
    [SerializeField] float GameTime;
    private float _gameTime;

    // Player
    [SerializeField] Character Moth;
    [SerializeField] float DropLifeTime;

    [SerializeField] Canvas EndScreen;

    private float Score;

    private GameObject[] DropList;
    private const int MaxDropAmount = 16;

    private GameObject[] SpawnedEnemies;

    private bool[] RecentTriggers;

    private Vector2 StartMothPos;

    void StartGame()
    {
        _gameTime = GameTime;
        Score = 0;
        UpdateScore();
        UpdateTimer();

        EndScreen.gameObject.SetActive(false);

        for (int j = 0; j < Enemies.Length; j++)
        {
            StartCoroutine(RespawnEnemy(EnemySpawnCoordinates[j], j));
        }
    }

    private void Start()
    {
        StartMothPos = (Vector2)Moth.Rb.transform.position;

        if (Enemies.Length != EnemySpawnCoordinates.Length)
        {
            throw new Exception("Enemies & spawns missmatch");
        }

        SpawnedEnemies = new GameObject[Enemies.Length];
        DropList = new GameObject[MaxDropAmount];
        RecentTriggers = new bool[Enemies.Length];

        DropButtonScript.SpawnEvent += SpawnDrop;
        EnemyCollision.CollisionEvent += HandleCollisionEvent;
        RestartButton.RestartEvent += Restart;
        ExitButton.ExitEvent += HandleExit;

        for (int j = 0; j < Enemies.Length; j++)
        {
            RecentTriggers[j] = false;
        }

        StartGame();
    }
    private void Restart()
    {
        DestroyAll();
        Moth.Rb.transform.position = StartMothPos;
        GameTime = _gameTime;
        Time.timeScale = 1;
        StartGame();
    }
    
    private void DestroyAll()
    {
        foreach(GameObject gameObject in SpawnedEnemies)
        {
            if(gameObject != null)
            {
                Destroy(gameObject);
            }

        }
        foreach (GameObject gameObject in DropList)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }

    private void HandleCollisionEvent(GameObject enemy, float points)
    {
        if (!enemy.IsDestroyed())
        {
            Destroy(enemy);
            int enemyIndex = Array.FindIndex(EnemySpawnCoordinates, x => (Vector2)enemy.transform.position == x);

            if (enemyIndex > 0 & !RecentTriggers[enemyIndex])
            {
                RecentTriggers[enemyIndex] = true;
                StartCoroutine(RespawnEnemy(enemy.transform.position, enemyIndex));
                ChangeScore(points);
            }
        }
    }
    private void SpawnDrop(GameObject drop)
    {
        int index = Array.FindIndex(DropList, x => x == null);
        if (index < 0)
            return;
        DropList[index] = Instantiate(drop, Moth.Rb.position, Quaternion.identity);
        Destroy(DropList[index], DropLifeTime);
        StartCoroutine(CleanArrayAfterDestroy(index));
    }

    private IEnumerator CleanArrayAfterDestroy(int index)
    {
        yield return new WaitForSeconds(DropLifeTime);
        DropList[index] = null;
    }
    private IEnumerator RespawnEnemy(Vector2 vec, int arrIndex)
    {
        yield return new WaitForSeconds(EnemyRespawnTime);
        int rnd = UnityEngine.Random.Range(0, 2);
        RecentTriggers[arrIndex] = false;
        SpawnedEnemies[arrIndex] = Instantiate(Enemies[rnd], vec, Quaternion.identity);
    }

    private void ChangeScore(float newScore)
    {
        if (Score + newScore <= 0)
        {
            Score = 0;
        }
        else
        {
            Score += newScore;
        }
        UpdateScore();
    }
    private void UpdateScore()
    {
        ScoreText.text = $"SCORE {Mathf.FloorToInt(Score).ToString("D3")}";
    }

    private void UpdateTimer()
    {
        TimerText.text = $"{TimeSpan.FromSeconds(GameTime).ToString(@"mm\:ss")}";
    }

    private void Update()
    {
        if (GameTime > 0)
        {
            GameTime -= Time.deltaTime;
            UpdateTimer();
        }
        else
        {
            Time.timeScale = 0;
            EndScreen.gameObject.SetActive(true);

        }
    }

    private void HandleExit()
    {

    }
}
