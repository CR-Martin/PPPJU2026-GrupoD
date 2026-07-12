using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject currentSpawnedItem;


    private void Update()
    {
        if (currentSpawnedItem != null) return;

        SpawnInmune();
    }

    void SpawnInmune()
    {

        currentSpawnedItem = Spawn();
    }

    public GameObject Spawn()
    {
        return Instantiate(item,spawnPoint);
    }
}
