using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public delegate void PlayerMoveAction(Vector2 dir);
    public static event PlayerMoveAction MovePlayer;

    public static Action<Vector2> MoveCamera;
    public static Action Attack;

    public void OnMove(InputValue inputValue)
    {
        
    }

    public void OnLook(InputValue inputValue)
    {

       
    }

    public void OnAttack(InputValue inputValue) 
    {
    
    }
}
