using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : ObjectBase
{

    public override void Init(int hp, int damage)
    {
        base.Init(hp, damage);
        _moveSpeed = 80f;
        _dir = Vector3.back;
    }

    protected void Attack()
    {

    }

}
