using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject _eObj;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            _eObj.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            _eObj?.SetActive(false);
        }
    }
}
