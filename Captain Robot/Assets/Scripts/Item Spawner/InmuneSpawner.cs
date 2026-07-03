using UnityEngine;

public class InmuneSpawner : ItemSpawner
{
    private void OnEnable()
    {
        Inmune.OnInmunity += SpawnInmune;
    }

    private void OnDisable()
    {
        Inmune.OnInmunity -= SpawnInmune;
    }

    private void Start()
    {
        SpawnInmune();
    }

    void SpawnInmune()
    {
        Spawn();
    }
}
