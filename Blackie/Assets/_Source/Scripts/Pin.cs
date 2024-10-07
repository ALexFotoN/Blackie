using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isCollected = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }

    void Collect()
    {
        if (!isCollected)
        {
            isCollected = true;
            PlayerInventory.Instance.AddPin();
            gameObject.SetActive(false);
        }
    }
}