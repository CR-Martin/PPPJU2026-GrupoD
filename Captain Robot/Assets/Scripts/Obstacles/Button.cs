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

            if (interact.TryGetComponent<Iinteractable>(out Iinteractable interactable))
            {
                AudioManager.Instance.PlayEffect("Button");

                interactable.Interact();
                Destroy(collision.gameObject);

            }
        }
    }

   
}
