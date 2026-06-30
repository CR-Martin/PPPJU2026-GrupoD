using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPoint : MonoBehaviour
{
    [SerializeField] private string colliderTag;

    static public Action OnWinCollition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == colliderTag)
        {
            OnWinCollition?.Invoke();
        }
    }
}
