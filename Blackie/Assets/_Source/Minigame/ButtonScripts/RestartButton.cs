using System;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public static event Action RestartEvent;

    public void RestartButtonPressed()
    {
        RestartEvent.Invoke();
    }
}
