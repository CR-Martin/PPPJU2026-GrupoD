using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject interact;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We collide");
        if(collision.gameObject.tag == "Rock")
        {
            Debug.Log("Rock");

            interact.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            interact.SetActive(true);
        }
    }
}
