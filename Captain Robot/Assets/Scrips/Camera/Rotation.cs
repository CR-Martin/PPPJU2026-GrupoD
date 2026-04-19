using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Vector3 rotatePoint = Vector3.zero;

    void Update()
    {
        transform.RotateAround(rotatePoint, Vector3.up, 50 * Time.deltaTime);
    }
}
