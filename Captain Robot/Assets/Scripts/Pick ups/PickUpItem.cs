using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public static event Action<Item> OnCollision;
    private Iinteractable Iinteractable;
    RaycastHit hit;

    private float pickUpRange = 1f;

    private void OnEnable()
    {
        InputManager.OnSpace += DetectPickUp;
    }

    private void OnDisable()
    {
        InputManager.OnSpace -= DetectPickUp;
    }

    void DetectPickUp()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        {
            Debug.Log("ray");
            if (hit.transform.gameObject.TryGetComponent(out Item item))
            {
                Debug.Log("hit");

                OnCollision?.Invoke(item);

            }

            if (hit.transform.gameObject.TryGetComponent(out Iinteractable interactable))
            {
                Debug.Log("hit interact");

                interactable.Interact();

            }
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);

    }
  
}
