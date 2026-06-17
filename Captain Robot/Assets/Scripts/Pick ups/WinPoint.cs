using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPoint : MonoBehaviour
{
    [SerializeField] private string colliderTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == colliderTag)
        {
            SceneManager.LoadScene("mainMenu");

        }
    }
}
