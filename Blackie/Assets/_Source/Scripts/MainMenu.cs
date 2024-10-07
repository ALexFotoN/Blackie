using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] string _sceneName;
    public void Play()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Settings()
    {
    }

    public void Quit()
    {
        Application.Quit();
    }
}
