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

            // Desactivar colisiones
            Collider col = GetComponent<Collider>();
            if (col != null)
                col.enabled = false;

            // Desactivar f�sica
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // usa velocity si tu versi�n de Unity no tiene linearVelocity
                rb.isKinematic = true;
            }

            // Unir al jugador
            transform.SetParent(other.transform);
            transform.localPosition = offset;
            transform.localRotation = Quaternion.identity;

            // Evitar que se vuelva a activar
            enabled = false;
        }
    }
}