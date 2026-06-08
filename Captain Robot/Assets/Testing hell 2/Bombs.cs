using UnityEngine;

public class Bombs : Item
{
    public override Item DoAction()
    {
        Debug.Log("Accion");
        return this;
    }

    public override void DropItem()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
        Debug.Log("Drop");
    }
}
