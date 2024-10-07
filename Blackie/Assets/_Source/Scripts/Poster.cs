using UnityEngine;

public class Poster : MonoBehaviour
{
    private bool isCorrected = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            CorrectPoster();
        }
    }

    void CorrectPoster()
    {
        if (!isCorrected && PlayerInventory.Instance.PinsCount > 0)
        {
            isCorrected = true;
            PlayerInventory.Instance.UsePin();
            CheckAllPostersCorrected();
        }
    }

    void CheckAllPostersCorrected()
    {
        if (GameManager.Instance.AllPostersCorrected())
        {
            GameManager.Instance.SpawnDoor();
        }
    }
}
