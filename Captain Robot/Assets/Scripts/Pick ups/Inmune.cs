using UnityEngine;
using System.Collections;
using System;

public class Inmune : Item
{
    public static Action OnInmunity;
    public override void DoAction()
    {
        transform.SetParent(null);
        KinematicState(false);
        rb.useGravity = true;
        OnInmunity.Invoke();
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
