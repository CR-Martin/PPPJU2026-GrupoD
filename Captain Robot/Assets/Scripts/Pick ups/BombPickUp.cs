using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class BombPickUp : PickUpBase
{
    [SerializeField] GameObject playerBomb;

    public override void PickUpBehavior()
    {
        if (holder.CanPickUp()) return;
       /* holder.SpawnPickUp(playerBomb);
        Destroy(this.gameObject);*/

    }

}
