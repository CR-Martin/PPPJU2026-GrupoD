using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] Camera _camera;

    private Vector3 MouseRot;

    private void OnEnable()
    {
        InputManager.Attack += CameraMovement;
    }

    private void OnDisable()
    {
        InputManager.Attack -= CameraMovement;
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    MouseRot = _camera.ScreenToViewportPoint(Input.mousePosition);

        //}

        //if (Input.GetMouseButtonDown(0))
        //{

        //    Vector3 direction = MouseRot - _camera.ScreenToViewportPoint(Input.mousePosition);

        //    _camera.transform.position = new Vector3();

        //    _camera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
        //    _camera.transform.Rotate(new Vector3(0, 1, 0), direction.y * 180);
        //    _camera.transform.Translate(0, 0, -10);

        //    MouseRot = _camera.ScreenToViewportPoint(Input.mousePosition);
        //}
    }

    public void CameraMovement()
    {
        //MouseRot = inputValue;
       
    }
}
