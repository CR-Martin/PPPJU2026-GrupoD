using UnityEngine;

public class BootPickup : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 1.5f, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement movement = other.GetComponent<PlayerMovement>();
            SkateBootPower skateBoot = other.GetComponent<SkateBootPower>();

            if (movement != null) movement.enabled = false;
            if (skateBoot != null) skateBoot.enabled = true;

            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;

            transform.SetParent(other.transform);
            transform.localPosition = offset;
        }
    }
}