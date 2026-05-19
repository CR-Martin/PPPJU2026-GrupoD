using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpHolder : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] public Dictionary<string, GameObject> pickUpDataBase = new Dictionary<string, GameObject>();

    private void Start()
    {
        
    }
    public void SpawnPickUp(string key)
    {
        GameObject temp = pickUpDataBase[key];
        Instantiate(temp, spawnPoint.transform);
    }

    public void SpawnPickUp2(GameObject temp)
    {
        Instantiate(temp, spawnPoint.transform);
    }
}
