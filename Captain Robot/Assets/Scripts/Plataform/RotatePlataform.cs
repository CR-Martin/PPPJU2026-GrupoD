using UnityEngine;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;

public class RotatePlataform : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float waitTime = 5f;

    private Quaternion startRotation;
    private Quaternion targetRotation;

    private bool ifTimeStop; 

    [SerializeField] private Vector3 rotationAngle;

    private void OnEnable()
    {
        TimeStop.OnTimeStop += StopTime;

    }

    private void OnDisable()
    {
        TimeStop.OnTimeStop -= StopTime;

    }

    private void StopTime(float time)
    {
        StartCoroutine(StopForATime(time));

      
    }

    void Start()
    {
        ifTimeStop = false;
        startRotation = transform.rotation;
        targetRotation = startRotation * Quaternion.Euler(rotationAngle);

        StartCoroutine(RotationLoop());
    }

    IEnumerator RotationLoop()
    {
        while (ifTimeStop == false)
        {
            yield return RotateTo(targetRotation);

            yield return new WaitForSeconds(waitTime);

            yield return RotateTo(startRotation);

            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator RotateTo(Quaternion target)
    {
       
            while (Quaternion.Angle(transform.rotation, target) > 0.1f )
            {
            while (ifTimeStop)
                yield return null;
            transform.rotation = Quaternion.RotateTowards(

                    transform.rotation,
                     target,
                    rotationSpeed * Time.deltaTime
                );

                yield return null;
            }
           

        transform.rotation = target;
    }

    IEnumerator StopForATime(float time)
    {

        Debug.Log("Stop");
        ifTimeStop = !ifTimeStop;

        yield return new WaitForSeconds(time);

        Debug.Log("Sto 2p");
        ifTimeStop = !ifTimeStop;
    }
}
