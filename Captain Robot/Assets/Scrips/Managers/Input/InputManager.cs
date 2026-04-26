using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public delegate void PlayerMoveAction(Vector2 dir);
    public static event PlayerMoveAction MovePlayer;

  //  public static Action<Vector2> MoveCamera;
    public static Action Attack;

    public void OnMove(InputValue inputValue)
    {
        var movementInput = inputValue.Get<Vector2>();
        Debug.Log(movementInput);
        MovePlayer(movementInput);
    }

    public void OnLook(InputValue inputValue)
    {

        var cameraInput = inputValue.Get<Vector2>();
        //MoveCamera(cameraInput);
    }

    public void OnAttack(InputValue inputValue) 
    {
       // Debug.Log("attack");
        Attack();
    }
}
