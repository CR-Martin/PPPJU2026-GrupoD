using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) )
        {

            TryPause();

        }
    }

    void TryPause()
    {
        if (Time.timeScale == 1)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("mainMenu");

    }
}
