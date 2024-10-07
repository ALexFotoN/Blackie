using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerInventory.Instance.HasKey)
            {
                SceneManager.LoadScene("Outdoor");
            }
        }
    }
}
