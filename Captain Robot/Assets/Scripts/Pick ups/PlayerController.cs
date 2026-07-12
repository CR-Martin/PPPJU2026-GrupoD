using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform handPosition;

    Item currentItem;

    public static event Action OnPickUp;
    public static event Action OnDropAction;

    private void OnEnable()
    {
        InputManager.OnDrop += DropItem;
        InputManager.OnActivate += ActivateItem;

        PickUpItem.OnCollision += PlayerPicker_OnPickUp;
    }

    private void OnDisable()
    {
        InputManager.OnDrop -= DropItem;
        InputManager.OnActivate -= ActivateItem;

        PickUpItem.OnCollision -= PlayerPicker_OnPickUp;

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
       
        AudioManager.Instance.PlayEffect("Pick Up");

        currentItem = item;
        item.transform.SetParent(handPosition);

        item.transform.localPosition = Vector3.zero;
        item.KinematicState(true);
        OnPickUp?.Invoke();
    }

    public void ActivateItem()
    {

        if (currentItem != null)
        {
            currentItem.DoAction();
            PlayerDropItem();
            OnDropAction?.Invoke();

        }
    }
    public void DropItem()
    {

        if (currentItem != null)
        {
            AudioManager.Instance.PlayEffect("Drop");

            currentItem.DropItem();
            PlayerDropItem();
            OnDropAction?.Invoke();

        }
    }
    void PlayerDropItem()
    {
        currentItem = null;
    }
}
