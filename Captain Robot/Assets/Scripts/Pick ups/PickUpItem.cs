using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public static event Action<Item> OnCollision;
    private Iinteractable Iinteractable;
    RaycastHit hit;

    private float pickUpRange = 1f;

    public void DetectPickUp()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        {
            if (hit.transform.gameObject.TryGetComponent(out Item item))
            {

                OnCollision?.Invoke(item);

            }

            if (hit.transform.gameObject.TryGetComponent(out Iinteractable interactable))
            {

                interactable.Interact();

            }
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);

    }
  
}
