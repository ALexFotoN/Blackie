using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        [Serializable]
        public class Dialog
        {
            public int spriteID;
            public int charID;
            public string text;
        }
        [SerializeField] List<Dialog> _dialogList = new List<Dialog>();
        int _dialogNum = 0;
        [SerializeField] GameObject _dialogBox;
        //[SerializeField] GameObject _button;
        DialogueBox _manager;
        bool _isShowing = false;
        [SerializeField] bool _nonInteractable;

        void Awake()
        {
            _manager = _dialogBox.GetComponent<DialogueBox>();
            if (_nonInteractable == true)
            {
                _isShowing = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //_button.SetActive(true);
            _isShowing = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            //_button.SetActive(false);
            _isShowing = false;
        }


        void Update()
        {
            if (_isShowing == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || _nonInteractable == true)
                {
                    Time.timeScale = 0f;
                    //_button.SetActive(false);
                    Dialogs();
                    _dialogBox.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _dialogNum++;
                    Dialogs();
                }
            }
        }

        void Dialogs()
        {
            if (_dialogNum < _dialogList.Count)
            {

                _manager.Change(_dialogList[_dialogNum].spriteID, _dialogList[_dialogNum].charID, _dialogList[_dialogNum].text);
            }
            else
            {
                _isShowing = false;
                _dialogNum = 0;
                _manager.Close();
            }
        }
    }
}

