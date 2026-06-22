using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform handPosition;

    [SerializeField] PickUpItem pickUpItem;

    //public Action OnSpace;

    Item currentItem;
    Item lastItem;
    private void OnEnable()
    {
        pickUpItem.OnCollision += PlayerPicker_OnPickUp;
    }

    private void OnDisable()
    {
        pickUpItem.OnCollision -= PlayerPicker_OnPickUp;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && currentItem != null)
        {
           
            currentItem.DoAction();
            PlayerDropItem();

        }

        if (Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            currentItem.DropItem();
            PlayerDropItem();
        }

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

    void PlayerDropItem()
    {
        currentItem = null;
    }
}
