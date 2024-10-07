using UnityEngine;

public class MatchableObject : MonoBehaviour
{
    private bool isMatched = false;

    public void Interact()
    {
        if (!isMatched)
        {
            isMatched = true;
            Debug.Log("Object matched!");

            GameManager.Instance.RegisterMatch();
        }
    }
}
