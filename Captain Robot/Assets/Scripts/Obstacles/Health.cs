using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
