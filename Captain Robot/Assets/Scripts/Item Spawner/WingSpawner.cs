using UnityEngine;

public class WingSpawner : ItemSpawner
{
    private void OnEnable()
    {
        Wings.OnFlying += SpawnWing;
    }

    private void OnDisable()
    {
        Wings.OnFlying -= SpawnWing;
    }

    private void Start()
    {
        SpawnWing();
    }

    void SpawnWing()
    {
        Spawn();
    }
}
