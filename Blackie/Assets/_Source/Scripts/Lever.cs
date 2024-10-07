using UnityEngine;

public class Lever : MonoBehaviour
{
    public void Interact()
    {
        if (GameManager.Instance.CanUnlockFlier())
        {
            Debug.Log("Advertising flyer unlocked!");
        }
        else
        {
            Debug.Log("Need more paper pieces!");
        }
    }
}