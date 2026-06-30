using UnityEngine;

public class Rock : Item
{
    public override void DoAction()
    {
        transform.SetParent(null);
        KinematicState(false);
        rb.useGravity = true;

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
