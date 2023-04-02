using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteor : EnemyBase
{
    public override void Init()
    {
        _hp = 10;
        _maxHp = _hp;
        _damage = 10;


        _hArea.x = -25f;
        _hArea.y = 25f;

        _vArea.x = -40;
        _vArea.y = 40;

        _moveSpeed = 15;

        _h = 0;
        _v = -1;
        SetDir();
    }

    void Update()
    {
        CheckArea();

        Move();
    }
}
