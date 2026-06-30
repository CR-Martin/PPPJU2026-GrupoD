using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour
{

    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference pickUp;
    [SerializeField] private InputActionReference drop;
    [SerializeField] private InputActionReference activate;
    [SerializeField] private InputActionReference pause;

    public static event Action<Vector2> OnPlayerMove;
    public static event Action OnSpace;
    public static event Action OnDrop;
    public static event Action OnActivate;
    public static event Action OnPause;

    private void OnEnable()
    {
        move.action.Enable();
        move.action.performed += MovePlayer;
        move.action.canceled += MovePlayer;

        pickUp.action.Enable();
        pickUp.action.canceled += PickUpItem;

        drop.action.Enable();
        drop.action.canceled += DropItem;

        activate.action.Enable();
        activate.action.canceled += ActivateItem;

        pause.action.Enable();
        activate.action.canceled += Pause;


    }

    private void OnDisable()
    {
        move.action.Disable();
        move.action.performed -= MovePlayer;
        move.action.canceled -= MovePlayer;

        pickUp.action.Disable();
        pickUp.action.canceled -= PickUpItem;


        drop.action.Disable();
        drop.action.canceled -= DropItem;

        activate.action.Disable();
        activate.action.canceled -= ActivateItem;

        pause.action.Disable();
        activate.action.canceled -= Pause;
    }



    private void MovePlayer(InputAction.CallbackContext obj)
    {
        var movementInput = obj.ReadValue<Vector2>();
        OnPlayerMove?.Invoke(movementInput);
    }

    private void PickUpItem(InputAction.CallbackContext obj)
    {
        OnSpace?.Invoke();
    }

    private void DropItem(InputAction.CallbackContext obj)
    {
        OnDrop?.Invoke();
    }

    private void ActivateItem(InputAction.CallbackContext obj)
    {
        OnActivate?.Invoke();
    }

    private void Pause(InputAction.CallbackContext obj)
    {
        OnPause?.Invoke();
    }
    public void OnLook(InputValue inputValue)
    {

        var cameraInput = inputValue.Get<Vector2>();
        //MoveCamera(cameraInput);
    }
}
