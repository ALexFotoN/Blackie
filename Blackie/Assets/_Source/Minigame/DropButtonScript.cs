using CharacterSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropButtonScript : MonoBehaviour
{
    [SerializeField] GameObject SpawnableBerryPrefab;
    [SerializeField] Character Spawner;
    [SerializeField] float LifeTime;

    public void DropBerryButtonPressed()
    {
        Vector2 position = new Vector2(Spawner.Rb.position.x, Spawner.Rb.position.y);
        GameObject newBerry = Instantiate(SpawnableBerryPrefab, position, Quaternion.identity);
        Destroy(newBerry, LifeTime);
    }

}
