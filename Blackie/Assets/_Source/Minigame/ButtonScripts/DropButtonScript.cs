using System;
using UnityEngine;

public class DropButtonScript : MonoBehaviour
{
    [SerializeField] GameObject SpawnablePrefab;

    public static event Action<GameObject> SpawnEvent;
    public void DropButtonPressed()
    {
        SpawnEvent.Invoke(SpawnablePrefab);
    }
}
