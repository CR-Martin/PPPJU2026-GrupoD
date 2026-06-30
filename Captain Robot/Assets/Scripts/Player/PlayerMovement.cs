using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 _moveDirection;

    [SerializeField] private float horizontalAcceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Camera cam;

    private void OnEnable()
    {
        InputManager.OnPlayerMove += MovePlayer;

    }
    private void OnDisable()
    {
        InputManager.OnPlayerMove -= MovePlayer;

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
  

    private void FixedUpdate()
    {
        if (_moveDirection.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(_moveDirection.x, _moveDirection.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.linearVelocity = moveDir * horizontalAcceleration + Vector3.up * rb.linearVelocity.y;
        }
        else
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }

    }

    void MovePlayer(Vector2 dir)
    {
        var movementInput = dir;

        _moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
    }
}
