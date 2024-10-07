using UnityEngine;

public class CheckBookOrder : MonoBehaviour
{
    public GameObject[] bookStacks;
    public Vector3[] correctPositions;
    public GameObject keyPrefab;
    private bool isPuzzleSolved = false;

    void Update()
    {
        if (!isPuzzleSolved && IsCorrectOrder())
        {
            isPuzzleSolved = true;
            Instantiate(keyPrefab, this.transform.position, Quaternion.identity);
        }
    }

    private bool IsCorrectOrder()
    {
        for (int i = 0; i < bookStacks.Length; i++)
        {
            if (Vector3.Distance(bookStacks[i].transform.position, correctPositions[i]) > 0.1f)
            {
                return false;
            }
        }
        return true;
    }
}