using UnityEngine;
using System.Collections;

public class Bombs : Item
{
    private float forceThrow = 1000;
    private int maxTimer = 3;

    public override Item DoAction()
    {
        transform.SetParent(null);
        KinematicState(false);
        rb.useGravity = true;

        rb.AddForce(transform.forward * forceThrow);
        StartCoroutine("Explode");
        return this;
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

        foreach (RaycastHit colliders in hits)
        {
            Debug.Log(colliders.transform.gameObject);

            if (colliders.transform.GetComponent<IDamageable>() != null)
            {
                isHit = colliders.transform.GetComponent<IDamageable>();
                isHit.TakeDamage();
            }
        }

        yield return null;
    }
}
