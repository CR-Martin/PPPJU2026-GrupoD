using UnityEngine;
using System.Collections;
using System;
using static UnityEngine.ParticleSystem;

public class Bombs : Item
{
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private float effectLifetime = 2f; // used only if the effect doesn't self-destroy

    private float forceThrow = 100;
    private int maxTimer = 3;

    public static Action OnExplosion;
    public override void DoAction()
    {
        transform.SetParent(null);
        KinematicState(false);
        rb.useGravity = true;
        fireEffect.gameObject.SetActive(true);
        rb.AddForce(transform.forward * forceThrow);
        StartCoroutine("Explode");
    }

    public override void DropItem()
    {
        transform.SetParent(null);
        KinematicState(false);
    }

    public override void KinematicState(bool state)
    {
        rb.isKinematic = state;
    }

    IEnumerator Explode()
    {

        yield return new WaitForSeconds(maxTimer);

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 2f, -transform.up, 5f);
        IDamageable isHit;

        AudioManager.Instance.PlayEffect("Bomb");

        Instantiate(explosionEffect, transform.position, Quaternion.identity, gameObject.transform);

        if (explosionEffect != null)
        {
            ParticleSystem effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effectLifetime); // safety net if "Stop Action: Destroy" isn't set
        }

        foreach (RaycastHit colliders in hits)
        {

            if (colliders.transform.GetComponent<IDamageable>() != null)
            {
                isHit = colliders.transform.GetComponent<IDamageable>();
                isHit.TakeDamage();
            }
        }
        OnExplosion?.Invoke();
        Destroy(gameObject);

        yield return null;
    }
}
