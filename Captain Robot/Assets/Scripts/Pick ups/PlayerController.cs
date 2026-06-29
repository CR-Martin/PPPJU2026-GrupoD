using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform handPosition;

    [SerializeField] PickUpItem pickUpItem;


    Item currentItem;
    private void OnEnable()
    {
        InputManager.OnDrop += DropItem;
        InputManager.OnActivate += ActivateItem;

        pickUpItem.OnCollision += PlayerPicker_OnPickUp;
    }

    private void OnDisable()
    {
        InputManager.OnDrop -= DropItem;
        InputManager.OnActivate -= ActivateItem;

        pickUpItem.OnCollision -= PlayerPicker_OnPickUp;

    }

    void Update()
    {       

        if (currentItem != null)
        {
            currentItem.transform.forward = this.transform.forward;
        }
    }

    void PlayerPicker_OnPickUp(Item item)
    {
       
        Debug.Log("Hacemos pick up");

        currentItem = item;
        item.transform.SetParent(handPosition);

        item.transform.localPosition = Vector3.zero;
        item.KinematicState(true);
    }

    public void ActivateItem()
    {

        if (currentItem != null)
        {
            currentItem.DoAction();
            PlayerDropItem();
        }
    }
    public void DropItem()
    {

        if (currentItem != null)
        {

            currentItem.DropItem();
            PlayerDropItem();
        }
    }
    void PlayerDropItem()
    {
        currentItem = null;
    }
}
