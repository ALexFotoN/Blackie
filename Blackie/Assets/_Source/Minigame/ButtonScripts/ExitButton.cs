using System;
using UnityEngine;
public class ExitButton : MonoBehaviour
{
    public static event Action ExitEvent;

    public void ExitButtonPressed()
    {
        ExitEvent.Invoke();
    }
}
