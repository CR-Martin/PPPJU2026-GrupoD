using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Jugar()
    {
        SceneManager.LoadScene("inGame");
    }

    public void Opciones()
    {
        Debug.Log("SIN HACER. Abrir opciones");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Credits");
    }

    public void SalirCreditos()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}