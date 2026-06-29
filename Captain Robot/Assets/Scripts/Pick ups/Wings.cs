using UnityEngine;
using System;

public class Wings : Item
{
    public static event Action OnFlying;

    public override void DoAction()
    {
        transform.SetParent(null);
        KinematicState(false);
        rb.useGravity = true;
        OnFlying.Invoke();
        Destroy(gameObject);
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
