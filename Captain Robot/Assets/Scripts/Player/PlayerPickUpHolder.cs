using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpHolder : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private GameObject currentPickUp;

    private void OnEnable()
    {
        Objectopick.OnTest += SpawnPickUp;
    }

    private void OnDisable()
    {
        Objectopick.OnTest -= SpawnPickUp;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentPickUp != null)
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        IWorldSpawn worldSpawn = currentPickUp.GetComponent<IWorldSpawn>();
        worldSpawn.WorldSpawn(spawnPoint);
        currentPickUp = null;
        foreach (Transform child in spawnPoint)
        {
            GameObject.Destroy(child.gameObject);
        }

    }
    public void SpawnPickUp(GameObject temp)
    {
        currentPickUp = temp;
        Instantiate(temp, spawnPoint.transform);
    }

    public bool CanPickUp()
    {
        if (!currentPickUp) return false;
        return true;
    }
}
