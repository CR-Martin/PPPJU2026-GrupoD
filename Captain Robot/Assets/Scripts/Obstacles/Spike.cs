using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("hit interact");

            damageable.TakeDamage();

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.gameObject.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("hit interact");

            damageable.TakeDamage();

        }
    }
}
