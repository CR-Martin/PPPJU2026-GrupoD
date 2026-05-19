using UnityEngine;
using System;
using UnityEngine.WSA;

public abstract class PickUpBase : MonoBehaviour
{
    [SerializeField] private string collisionTag;
    public PlayerPickUpHolder holder;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == collisionTag)
        {
            holder = collision.gameObject.GetComponent<PlayerPickUpHolder>();
            PickUpBehavior();
        }
    }

    abstract public void PickUpBehavior();
}
