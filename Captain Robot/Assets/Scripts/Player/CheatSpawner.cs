using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CheatSpawner : MonoBehaviour
{
    [SerializeField] GameObject flyPowerUp;

    [SerializeField] Transform spawnPoint;

    private void OnEnable()
    {
        InputManager.OnFly += Fly;
    }

    private void OnDisable()
    {
        InputManager.OnFly -= Fly;

    }
    private void Fly()
    {
        Spawn(flyPowerUp);
    }

    private void Spawn(GameObject refe)
    {
        Instantiate(refe, spawnPoint);

    }
}
