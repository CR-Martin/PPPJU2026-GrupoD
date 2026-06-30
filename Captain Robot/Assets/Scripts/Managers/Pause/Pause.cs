using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;

    private void OnEnable()
    {
        InputManager.OnPause += TryPause;

    }

    private void OnDisable()
    {
        InputManager.OnPause -= TryPause;
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
