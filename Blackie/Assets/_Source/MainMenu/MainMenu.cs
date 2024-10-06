using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Room");
    }

    public void Settings()
    {
    }

    public void Quit()
    {
        Application.Quit();
    }
}
