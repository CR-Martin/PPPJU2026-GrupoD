using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxLife;
    private bool immune = false;

    private float tempLife;

    public static Action OnGameOver;
    void Start()
    {
        tempLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempLife == 0)
        {
            OnGameOver?.Invoke();
        }
    }

    public void TakeDamage()
    {
        if (immune == false)
        {
            tempLife--;
            StartCoroutine(immunity());
        }
    }
    IEnumerator immunity()
    {
        immune = true;
        yield return new WaitForSeconds(3);
        immune = false;
    }
}
