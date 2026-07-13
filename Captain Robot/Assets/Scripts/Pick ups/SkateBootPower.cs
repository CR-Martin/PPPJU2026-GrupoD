using UnityEngine;

public class SkateBootPower : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float acceleration = 20f;
    public float deceleration = 5f;
    public float bounceForce = 1f;

    private Vector3 velocity;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = (transform.right * h + transform.forward * v).normalized;

        if (input.magnitude > 0)
        {
            velocity = Vector3.MoveTowards(velocity, input * maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, deceleration * Time.deltaTime);
        }

        transform.position += velocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        velocity = Vector3.Reflect(velocity, contact.normal) * bounceForce;
    }
}