using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour
{
    public Action OnSpace;

    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference pickUp;

    public static event Action<Vector2> OnPlayerMove;

    private void OnEnable()
    {
        move.action.Enable();
        move.action.performed += MovePlayer;
        move.action.canceled += MovePlayer;

        pickUp.action.Enable();

        pickUp.action.canceled += PickUpItem;


    }

    private void OnDisable()
    {
        move.action.Disable();
        move.action.performed -= MovePlayer;
        move.action.canceled -= MovePlayer;

        pickUp.action.Disable();

        pickUp.action.canceled -= PickUpItem;



    }

   

    private void MovePlayer(InputAction.CallbackContext obj)
    {
        var movementInput = obj.ReadValue<Vector2>();
        OnPlayerMove?.Invoke(movementInput);
    }

    private void PickUpItem(InputAction.CallbackContext obj)
    {
        ////Debug.Log("Espace");
        OnSpace?.Invoke();

     
            Debug.Log("Cancelled");
      

            //}

            //if (obj.performed)
            //{
            //    Debug.Log("performed");
            //}



    }

    public void OnLook(InputValue inputValue)
    {

        var cameraInput = inputValue.Get<Vector2>();
        //MoveCamera(cameraInput);
    }
}
