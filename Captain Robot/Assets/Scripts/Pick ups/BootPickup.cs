using UnityEngine;

public class BootPickup : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 1.5f, 0);

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

            Collider col = GetComponent<Collider>();
            if (col != null)
                col.enabled = false;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            transform.SetParent(other.transform);
            transform.localPosition = offset;
            transform.localRotation = Quaternion.identity;

            enabled = false;
        }
    }
}