using UnityEngine;

public class BombSpawner : ItemSpawner
{
    private void OnEnable()
    {
        Bombs.OnExplosion += SpawnBomb;
    }
    void SpawnBomb()
    {
        Spawn();
    }
}
