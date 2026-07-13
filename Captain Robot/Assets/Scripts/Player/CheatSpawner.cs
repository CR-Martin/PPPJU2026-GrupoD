using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CheatSpawner : MonoBehaviour
{
    [SerializeField] GameObject flyPowerUp;
    [SerializeField] GameObject inmunePowerUp;
    [SerializeField] GameObject rockPickUp;
    [SerializeField] GameObject bombPickUp;
    [SerializeField] GameObject timeStopPickUp;

    [SerializeField] Transform spawnPoint;

    private void OnEnable()
    {
        InputManager.OnCheat += Fly;
    }

    private void OnDisable()
    {
        InputManager.OnCheat -= Fly;

    }
    private void Fly()
    {
        Spawn(flyPowerUp);
        Spawn(inmunePowerUp);
        Spawn(rockPickUp);
        Spawn(bombPickUp);
        Spawn(timeStopPickUp);

    }

    private void Spawn(GameObject refe)
    {
        GameObject temp = Instantiate(refe, spawnPoint);
        temp.transform.SetParent(null);

    }
}
