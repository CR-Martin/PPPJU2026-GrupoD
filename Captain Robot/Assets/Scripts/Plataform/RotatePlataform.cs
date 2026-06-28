using UnityEngine;
using System.Collections;

public class RotatePlataform : MonoBehaviour
{
    public float rotationSpeed = 90f; // Degrees per second
    public float waitTime = 5f;

    private Quaternion startRotation;
    private Quaternion targetRotation;

    [SerializeField] private Vector3 rotationAngle;
    void Start()
    {
        startRotation = transform.rotation;
        targetRotation = startRotation * Quaternion.Euler(rotationAngle);

        StartCoroutine(RotationLoop());
    }

    IEnumerator RotationLoop()
    {
        while (true)
        {
            // Rotate to 90 degrees
            yield return RotateTo(targetRotation);

            // Wait
            yield return new WaitForSeconds(waitTime);

            // Rotate back
            yield return RotateTo(startRotation);

            // Wait before repeating (optional)
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator RotateTo(Quaternion target)
    {
        while (Quaternion.Angle(transform.rotation, target) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(
               
                transform.rotation,
                 target,
                rotationSpeed * Time.deltaTime
            );

            yield return null;
        }

        transform.rotation = target;
    }
}
