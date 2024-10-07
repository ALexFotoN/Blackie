using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject doorPrefab;
    private int correctedPosters = 0;
    private int totalPosters = 4;
    private int requiredMatches = 3;
    private int currentMatches = 0;
    private int paperPieces = 0;

    void Awake()
    {
        Instance = this;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CorrectPoster()
    {
        correctedPosters++;
    }

    public bool AllPostersCorrected()
    {
        return correctedPosters >= totalPosters;
    }

    public void SpawnDoor()
    {
        //Instantiate(doorPrefab, somePosition, Quaternion.identity);
    }

    public void RegisterMatch()
    {
        currentMatches++;
        if (currentMatches >= requiredMatches)
        {
            GivePaperPieces();
        }
    }

    void GivePaperPieces()
    {
        paperPieces += 6;
        Debug.Log("6 paper pieces acquired!");
    }

    public bool CanUnlockFlier()
    {
        return paperPieces >= 12;
    }
}
