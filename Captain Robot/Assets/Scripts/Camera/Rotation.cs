using UnityEngine;

public class CameraRotation: MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;

    [Header("Camara")]
    [SerializeField] private float distanceToTarget = 5f;
    [SerializeField] private float mouseSensitivity = 180f;

    private Vector3 previousPosition;

    void Update()
    {
        HandleCameraRotation();
        AlignPlayerWithCamera();
    }

    void HandleCameraRotation()
    {
        cam.transform.position = target.position;

        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationY = -direction.x * mouseSensitivity;
            float rotationX = direction.y * mouseSensitivity;

            cam.transform.Rotate(Vector3.right, rotationX); // Rotación vertical (solo cámara)

            cam.transform.Rotate(Vector3.up, rotationY, Space.World); // Rotación horizontal (solo cámara)

            previousPosition = newPosition;
        }

        // Mantener distancia
        cam.transform.position = target.position;
        cam.transform.Translate(0, 0, -distanceToTarget);
    }

    void AlignPlayerWithCamera()
    {
        // Dirección hacia donde mira la cámara
        Vector3 forward = cam.transform.forward;
        forward.y = 0;

        if (forward.sqrMagnitude > 0.001f)
        {
            target.rotation = Quaternion.LookRotation(forward);
        }
    }
}