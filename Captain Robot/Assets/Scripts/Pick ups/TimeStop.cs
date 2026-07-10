using UnityEngine;
using System;

public class TimeStop : Item
{
    [SerializeField] private float time;
    public static event Action<float> OnTimeStop;

    public override void DoAction()
    {
        transform.SetParent(null);
        KinematicState(false);
        rb.useGravity = true;
        OnTimeStop.Invoke(time);
        AudioManager.Instance.PlayEffect("Fly");
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
