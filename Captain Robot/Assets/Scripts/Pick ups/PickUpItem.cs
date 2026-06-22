using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] InputManager playerController;
    public Action<Item> OnCollision;

    RaycastHit hit;

    private float pickUpRange = 1f;

    private void OnEnable()
    {
        playerController.OnSpace += DetectPickUp;
    }

    private void OnDisable()
    {
        playerController.OnSpace -= DetectPickUp;
    }

    void DetectPickUp()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        {
            if (hit.transform.gameObject.TryGetComponent(out Item item))
            {
                OnCollision?.Invoke(item);

            }
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);

    }
  
}
