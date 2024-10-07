using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace DialogueSystem
{
    public class DialogueBox : MonoBehaviour
    {
        [SerializeField] List<Sprite> _sprites;
        [SerializeField] List<string> _names;
        [SerializeField] GameObject _imageObj;
        [SerializeField] TextMeshProUGUI _name;
        [SerializeField] TextMeshProUGUI _text;

        private void Awake()
        {
            List<Sprite> sprites = new List<Sprite>();
            List<string> names = new List<string>();
        }

        public void Open()
        {
            Time.timeScale = 1.0f;
            gameObject.SetActive(true);
        }

        public void Change(int _spriteID, int _characterID, string _textOut)
        {
            _imageObj.GetComponent<Image>().sprite = _sprites[_spriteID];
            _name.text = _names[_characterID];
            _text.text = _textOut;
        }

        public void Close()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }

}
