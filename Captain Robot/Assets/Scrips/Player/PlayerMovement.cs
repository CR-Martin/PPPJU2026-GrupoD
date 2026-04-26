using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Rigidbody rigidBody;

    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10f;

    private Vector3 _currentMovement;

    float Myfloat;

    private void OnEnable()
    {
        rigidBody ??= GetComponent<Rigidbody>();
        InputManager.MovePlayer += Movement;
    }


    private void OnDisable()
    {
        InputManager.MovePlayer -= Movement;
    }

    private void FixedUpdate()
    {
        if (_currentMovement.magnitude >= 1f)
        {
            rigidBody.MovePosition((Vector3)transform.position + _currentMovement * 10 * Time.deltaTime);
            float Angle = Mathf.Atan2(_currentMovement.x, _currentMovement.z) * Mathf.Rad2Deg;
            float Smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref Myfloat, 0.1f);
            transform.rotation = Quaternion.Euler(0, Smooth, 0);


        }

    }

    public void Movement(Vector2 direction)
    {
        var movementInput = direction;

        _currentMovement = new Vector3(movementInput.x, 0, movementInput.y);
    }
}
