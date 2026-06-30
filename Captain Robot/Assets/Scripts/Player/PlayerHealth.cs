using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxLife;
    private bool immune = false;

    private float tempLife;
    private int standarInmunity = 3;
    private int extendedInmunity = 10;

    public static Action OnGameOver;

    private void OnEnable()
    {
        Inmune.OnInmunity += LongInmunity;
    }

    private void OnDisable()
    {
        Inmune.OnInmunity -= LongInmunity;

    }

    void Start()
    {
        tempLife = maxLife;
    }

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
            StartCoroutine(immunity(standarInmunity));
        }
    }

    private void LongInmunity()
    {
        StartCoroutine(immunity(extendedInmunity));

    }
    IEnumerator immunity(int time)
    {
        immune = true;
        yield return new WaitForSeconds(time);
        immune = false;
    }
}
