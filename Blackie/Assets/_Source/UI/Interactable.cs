using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject _eObj;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            _eObj.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            _eObj?.SetActive(false);
        }
    }
}
