using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : ShooterBase
{

    protected override void OverVerticalArea()
    {
        Destroy(this.gameObject);
    }
}
