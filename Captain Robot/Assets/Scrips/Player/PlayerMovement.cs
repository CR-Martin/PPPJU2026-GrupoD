using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 _moveDirection;

    [SerializeField] private float horizontalAcceleration;
    [SerializeField] private float maxSpeed;

    float Myfloat;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _moveDirection = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        Vector3 horizontalVelocity = new Vector3(GetComponent<Rigidbody>().linearVelocity.x, 0f, GetComponent<Rigidbody>().linearVelocity.z);

        horizontalVelocity += _moveDirection * (horizontalAcceleration * Time.fixedDeltaTime);

        if (horizontalVelocity.magnitude >= maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
        }

        GetComponent<Rigidbody>().linearVelocity = new Vector3(horizontalVelocity.x, GetComponent<Rigidbody>().linearVelocity.y, horizontalVelocity.z);
    }


}
