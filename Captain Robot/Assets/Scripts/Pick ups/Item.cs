using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    
    public abstract void DoAction();

    public abstract void DropItem();

    public abstract void KinematicState(bool state);
}
