using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour, Iinteractable
{
    private float initialPosition;
    [SerializeField] private float elevatedPosition;
    [SerializeField] private float duration;

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

    private void Start()
    {
        ifTimeStop = false;
        initialPosition = gameObject.transform.position.y;
        elevatedPosition += initialPosition; 
    }

    public void Interact()
   {
        StartCoroutine(MoveY(initialPosition, elevatedPosition, duration));

    }


    IEnumerator MoveY(float fromY, float toY, float time)
    {
        float elapsed = 0f;
        Vector3 pos = transform.position;

        while (elapsed < time)
        {
            while (ifTimeStop)
                yield return null;

            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);
            t = Mathf.SmoothStep(0f, 1f, t);

            pos.y = Mathf.Lerp(fromY, toY, t);
            transform.position = pos;

            yield return null;
        }

        pos.y = toY;
        transform.position = pos;
    }

    IEnumerator StopForATime(float time)
    {

        ifTimeStop = !ifTimeStop;

        yield return new WaitForSeconds(time);

        ifTimeStop = !ifTimeStop;
    }

}
