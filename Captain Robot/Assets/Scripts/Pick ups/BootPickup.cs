using UnityEngine;

public class BootPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement movement =
                other.GetComponent<PlayerMovement>();

            SkateBootPower skateBoot =
                other.GetComponent<SkateBootPower>();

            if (movement != null)
                movement.enabled = false;

            if (skateBoot != null)
                skateBoot.enabled = true;

            Destroy(gameObject);
        }
    }
}