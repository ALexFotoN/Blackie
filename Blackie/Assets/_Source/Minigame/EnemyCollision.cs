using UnityEngine;
using System.Collections.Generic;
using System;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject CurrentEnemy; 
    [SerializeField] GameObject NeededObject;
    [SerializeField] float SuccessGain;
    [SerializeField] float FailGain;

    public static event Action<GameObject, float> CollisionEvent;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        float points = CurrentEnemy.tag == NeededObject.tag ? SuccessGain : FailGain;
        CollisionEvent.Invoke(CurrentEnemy, points);
    }
}
