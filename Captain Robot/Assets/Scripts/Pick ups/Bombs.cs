using UnityEngine;

public class Bombs : Item
{
    private float forceThrow = 100;
    public override Item DoAction()
    {
        transform.SetParent(null);
        KinematicState(false);
        rb.useGravity = true;

        rb.AddForce(transform.forward * forceThrow);
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
}
