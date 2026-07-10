using UnityEngine;

public class CameraRotation: MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;

    [Header("Camara")]
    [SerializeField] private float distanceToTarget = 5f;
    [SerializeField] private float mouseSensitivity = 1f;

    private Vector3 previousPosition;


    private Vector2 MouseRot;

    private bool firstClick;

    private void OnEnable()
    {
        InputManager.OnCameraStarted += CameraStarted;
        InputManager.OnCameraPerformed += CameraPerformed;
    }
    private void OnDisable()
    {
        InputManager.OnCameraStarted -= CameraStarted;
        InputManager.OnCameraPerformed -= CameraPerformed;
    }
    void Update()
    {
        HandleCameraRotation();
        AlignPlayerWithCamera();
    }

    void HandleCameraRotation()
    {
        cam.transform.position = target.position;

       
        cam.transform.position = target.position;
        cam.transform.Translate(0, 0, -distanceToTarget);
    }

    private void CameraStarted()
    {
        if (Time.timeScale == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    private void CameraPerformed()
    {
        if (Time.timeScale == 1)
        {
            Cursor.lockState = CursorLockMode.Confined;

            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationY = -direction.x * mouseSensitivity;
            float rotationX = direction.y * mouseSensitivity;

            cam.transform.Rotate(Vector3.right, rotationX);

            cam.transform.Rotate(Vector3.up, rotationY, Space.World);

            previousPosition = newPosition;
        }
      

    }


    void AlignPlayerWithCamera()
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0;

        if (forward.sqrMagnitude > 0.001f)
        {
            target.rotation = Quaternion.LookRotation(forward);
        }
    }
}