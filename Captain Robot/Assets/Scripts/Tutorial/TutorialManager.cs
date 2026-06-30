using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorials;

    void Start()
    {
        tutorials.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if(Time.timeScale == 1)
        {
            Destroy(tutorials);
        }
    }
    public void End()
    {
        tutorials.SetActive(false);
        Time.timeScale = 1;
    }
}
