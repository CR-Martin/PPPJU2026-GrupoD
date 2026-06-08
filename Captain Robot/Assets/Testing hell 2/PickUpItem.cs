using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Action<Item> OnCollision;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide");
        if (other.TryGetComponent(out Item item))
        {
            OnCollision?.Invoke(item);
        }
    }
}
