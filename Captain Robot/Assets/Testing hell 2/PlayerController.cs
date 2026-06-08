using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform handPosition;

    [SerializeField] PickUpItem pickUpItem;

    Item currentItem;

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
        }

        if (Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            currentItem.DropItem();
            PlayerDropItem();
        }
    }

    void PlayerPicker_OnPickUp(Item item)
    {
        currentItem = item;
        item.transform.SetParent(handPosition);
        item.transform.localPosition = Vector3.zero;
    }

    void PlayerDropItem()
    {
        currentItem = null;
    }
}
