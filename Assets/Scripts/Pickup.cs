using UnityEngine;
using System.Collections;

public class Pickup : ObjectCollision
{
    public override void ObjectHit()
    {
        base.ObjectHit();
		GameObject.Find("foundTreasures").GetComponent<TreasureCounter>().currentPickups++;
        Destroy(this.gameObject);
    }
}
