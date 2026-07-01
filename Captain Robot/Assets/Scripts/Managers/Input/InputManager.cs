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
    [SerializeField] private InputActionReference camaraStarted;
    [SerializeField] private InputActionReference camaraPerformed;

    [SerializeField] private InputActionReference inmuneCheat;
    [SerializeField] private InputActionReference flyCheat;
    [SerializeField] private InputActionReference winCheat;
    [SerializeField] private InputActionReference loseCheat;

    public static event Action<Vector2> OnPlayerMove;
    public static event Action OnSpace;
    public static event Action OnDrop;
    public static event Action OnActivate;
    public static event Action OnPause;
    public static event Action OnCameraStarted;
    public static event Action OnCameraPerformed;

    public static event Action OnInmune;
    public static event Action OnWinCheat; 
    public static event Action OnloseCheat;

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
        pause.action.canceled += Pause;

        camaraStarted.action.Enable();
        camaraStarted.action.started += CamaraStarted;

        camaraPerformed.action.Enable();
        camaraPerformed.action.performed += CamaraPerformed;
        camaraPerformed.action.canceled += CamaraPerformed;

        inmuneCheat.action.Enable();
        inmuneCheat.action.canceled += Inmune;

        winCheat.action.Enable();
        winCheat.action.canceled += Win;

        loseCheat.action.Enable();
        loseCheat.action.canceled += Lose;

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
        pause.action.canceled -= Pause;

        camaraStarted.action.Disable();
        camaraStarted.action.started += CamaraStarted;

        camaraPerformed.action.Disable();
        camaraPerformed.action.performed -= CamaraPerformed;
        camaraPerformed.action.canceled -= CamaraPerformed;

        inmuneCheat.action.Disable();
        inmuneCheat.action.canceled -= Inmune;

        winCheat.action.Disable();
        winCheat.action.canceled -= Win;

        loseCheat.action.Disable();
        loseCheat.action.canceled -= Lose;
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
        Debug.Log("Pause");

    }

    private void CamaraStarted(InputAction.CallbackContext obj)
    {
        OnCameraStarted?.Invoke();
        Debug.Log("UNO click");

    }
    private void CamaraPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("DOS click");

        OnCameraPerformed?.Invoke();
    }

    private void Inmune(InputAction.CallbackContext obj)
    {
        OnInmune?.Invoke();
    }

    private void Win(InputAction.CallbackContext obj)
    {
        OnWinCheat?.Invoke();
    }

    private void Lose(InputAction.CallbackContext obj)
    {
        OnloseCheat?.Invoke();
    }
}
