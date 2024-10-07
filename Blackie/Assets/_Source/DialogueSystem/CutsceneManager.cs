using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] List<string> _textList = new List<string>();
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] string sceneName;
    int _index = 0;

    private void Awake()
    {
        Cutscene();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _index++;
            Cutscene();
        }
    }

    void Cutscene()
    {
        if (_index < _textList.Count)
        {
            Change(_textList[_index]);
        }
        else
        {
            _index = 0;
            SceneManager.LoadScene(sceneName);
        }
    }

    void Change(string _textOut)
    {
        _text.text = _textOut;
    }
}
