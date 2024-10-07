using CharacterSystem;
using UnityEngine;

public class DropButtonScript : MonoBehaviour
{
    [SerializeField] GameObject SpawnablePrefab;
    [SerializeField] Character Spawner;
    [SerializeField] float LifeTime;

    public void DropButtonPressed()
    {
        Vector2 position = new Vector2(Spawner.Rb.position.x, Spawner.Rb.position.y);
        GameObject newBerry = Instantiate(SpawnablePrefab, position, Quaternion.identity);
        Destroy(newBerry, LifeTime);
    }

}
