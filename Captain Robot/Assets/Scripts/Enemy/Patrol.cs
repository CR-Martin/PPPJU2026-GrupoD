using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Patrol : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Settings")]
    public float speed = 2f;
    public float waitTime = 0.5f; 

    private Transform target;
    private bool waiting = false;
    private float waitTimer = 0f;

    private bool ifTimeStop;

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
        target = pointB;
        ifTimeStop = false;
    }

    void Update()
    {
        if (ifTimeStop == true)
        {

            return;
        }
     

        if (waiting)
        {

            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                waiting = false;
                waitTimer = 0f;
                target = (target == pointA) ? pointB : pointA;
            }
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        Vector3 direction = (target.position - transform.position);
       

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            waiting = true;
        }
    }

    IEnumerator StopForATime(float time)
    {

        ifTimeStop = !ifTimeStop;

        yield return new WaitForSeconds(time);

        ifTimeStop = !ifTimeStop;
    }
}
