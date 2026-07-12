using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorials;

    void Start()
    {
        tutorials.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;

    }

    private void Update()
    {
        if(Time.timeScale == 1)
        {
            Destroy(tutorials);
        }
        else
        {
            Debug.Log("Time scale 0");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void End()
    {
        tutorials.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
