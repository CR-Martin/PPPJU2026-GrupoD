using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour, Iinteractable
{
    private float initialPosition;
    [SerializeField] private float elevatedPosition;
    [SerializeField] private float duration;

    private void Start()
    {
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
}
