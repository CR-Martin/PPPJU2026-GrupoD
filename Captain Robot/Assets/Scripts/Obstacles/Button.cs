using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject interact;
    private bool hasBeenUse;

    private void Start()
    {
        hasBeenUse = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We collide");
        if(collision.gameObject.tag == "Rock" && hasBeenUse == false)
        {
            Debug.Log("Rock");

            if (interact.TryGetComponent<Iinteractable>(out Iinteractable interactable))
            {
                AudioManager.Instance.PlayEffect("Button");

                interactable.Interact();
                hasBeenUse = true;
                Destroy(collision.gameObject);

            }
        }
    }

   
}
