using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    //public delegate void PlayerMoveAction(Vector2 dir);
    //public static event PlayerMoveAction MovePlayer;

    public static Action Attack;

    public Action OnSpace;

    public static event Action<Vector2> OnPlayerMove;

    public void OnMove(InputValue inputValue)
    {
        var movementInput = inputValue.Get<Vector2>();
        OnPlayerMove?.Invoke(movementInput);
    }

    public void OnLook(InputValue inputValue)
    {

        var cameraInput = inputValue.Get<Vector2>();
        //MoveCamera(cameraInput);
    }

    public void OnPickUp(InputValue inputValue) 
    {
        Debug.Log("attack");
        //Attack();
        OnSpace?.Invoke();

    }
}
