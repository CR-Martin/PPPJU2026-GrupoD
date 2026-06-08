using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    
    public abstract Item DoAction();

    public abstract void DropItem();
}
