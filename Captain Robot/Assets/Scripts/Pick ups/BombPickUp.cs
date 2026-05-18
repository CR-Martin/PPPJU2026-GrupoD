using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class BombPickUp : PickUpBase
{
    private string spawnable = "bomb";
    [SerializeField] GameObject bomb;

    public override void PickUpBehavior()
    {
        holder.SpawnPickUp2(bomb);
        Debug.Log("Estoy");
        Destroy(this.gameObject);
    }

}
