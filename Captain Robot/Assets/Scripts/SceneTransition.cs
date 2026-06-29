using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTestingScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Testing");
        }
    }
}