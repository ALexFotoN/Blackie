using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    private int pins = 0;
    private bool hasKey = false;

    void Awake()
    {
        Instance = this;
    }

    public void AddPin()
    {
        pins++;
    }

    public void UsePin()
    {
        if (pins > 0)
            pins--;
    }

    public int PinsCount => pins;

    public void AddKey()
    {
        hasKey = true;
    }

    public bool HasKey => hasKey;
}
