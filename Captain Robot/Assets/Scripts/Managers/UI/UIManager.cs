using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject gameOverMenu;

    private void OnEnable()
    {
        WinPoint.OnWinCollition += WinGame;
    }

    private void OnDisable()
    {
        WinPoint.OnWinCollition -= WinGame;

    }
    void Update()
    {
        //TODO: MANDA ESTO A UN INPUT MANAGER
        if (Input.GetKeyUp(KeyCode.Escape))
        {

            Pause();

        }
    }

    private void Pause()
    {
        if (Time.timeScale == 1)
        {
            pauseMenu.SetActive(true);
            SetTimeToZero();
        }
        else
        {
            ResumeGameplay();
        }
    }

    private void GameOver()
    {
        SetTimeToZero();
        gameOverMenu.SetActive(true);

    }
    private void WinGame()
    {
        SetTimeToZero();
        winMenu.SetActive(true);
    }

    public void RelaodLevel()
    {
        SetTimeToOne();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void ChangeScene(string name)
    {
        SetTimeToOne();
        SceneManager.LoadScene(sceneName: name);
    }

    public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DeActivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ResumeGameplay()
    {
        pauseMenu.SetActive(false);
        SetTimeToOne();
    }
    private void SetTimeToZero()
    {
        Time.timeScale = 0f;
    }

    private void SetTimeToOne()
    {
        Time.timeScale = 1f;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
