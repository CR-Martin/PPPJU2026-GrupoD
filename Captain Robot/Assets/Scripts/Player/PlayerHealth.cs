using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxLife;
    private bool immune = false;
    private bool cheatImmune = false;

    private int tempLife;
    [SerializeField] private int standarInmunity = 3;
    [SerializeField] private int extendedInmunity = 10;

    [SerializeField] private GameObject  visual;

    public static Action OnGameOver;
    public static Action OnStarDamage;
    public static Action OnEndDamage;
    public static Action<int,int> OnLifeChange;

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
        OnLifeChange?.Invoke(tempLife, maxLife);
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
        if (immune == false && cheatImmune == false)
        {
            tempLife--;
            OnLifeChange?.Invoke(tempLife, maxLife);
            StartCoroutine(immunity(standarInmunity));
        }
    }

    private void LongInmunity()
    {
        StartCoroutine(Greaterimmunity(extendedInmunity));

    }
    IEnumerator immunity(int time)
    {
        immune = true;
        visual.SetActive(true);
        OnStarDamage?.Invoke();
        yield return new WaitForSeconds(time);
        visual.SetActive(false);
        OnEndDamage?.Invoke();
        immune = false;
    }

    IEnumerator Greaterimmunity(int time)
    {
        immune = true;
        visual.SetActive(true);
        yield return new WaitForSeconds(time);
        visual.SetActive(false);
        immune = false;
    }
    private void CheatInmune()
    {
        cheatImmune = !cheatImmune;
    }
}
