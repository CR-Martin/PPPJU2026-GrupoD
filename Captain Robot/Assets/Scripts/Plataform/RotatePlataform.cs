using UnityEngine;
using System.Collections;

public class RotatePlataform : MonoBehaviour
{
    public float rotationSpeed = 90f; 
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
            yield return RotateTo(targetRotation);

            yield return new WaitForSeconds(waitTime);

            yield return RotateTo(startRotation);

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
