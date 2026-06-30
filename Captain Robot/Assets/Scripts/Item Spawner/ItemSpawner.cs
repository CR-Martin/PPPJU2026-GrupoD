using UnityEngine;

public abstract class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private Transform spawnPoint;

    public void Spawn()
    {
        Instantiate(item,spawnPoint);
    }
}
