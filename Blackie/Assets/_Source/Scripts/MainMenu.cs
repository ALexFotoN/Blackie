using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{

    [SerializeField] string _sceneName;
    public void Play()
    {
        StartCoroutine(CoroutineTimer());

    }

    public void Settings()
    {
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator CoroutineTimer()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(_sceneName);
    }
}
