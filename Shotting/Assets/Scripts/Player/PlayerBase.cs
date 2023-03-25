using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : ObjectBase
{
    protected void GetDamage(Collider target)
    {
        EnemyBase enemyBase = target.transform.GetComponent<EnemyBase>();
        if (enemyBase)
        {
            enemyBase.GetDamage(_damage);
            Clear();
        }
    }
}
