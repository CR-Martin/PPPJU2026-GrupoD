using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class Objectopick : MonoBehaviour
{
    public static event Action<GameObject> OnTest;

    [SerializeField] private GameObject pickup;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Cool");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Cool2");
            OnTest?.Invoke(pickup);
        }
    }
}
