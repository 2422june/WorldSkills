using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyBase
{
    public override void Init()
    {
        _hp = 15;
        _maxHp = _hp;
        _damage = 5;


        _hArea.x = -25f;
        _hArea.y = 25f;

        _vArea.x = -40;
        _vArea.y = 40;

        _moveSpeed = 20;
    }

    void Update()
    {
        SetDir();
        CheckArea();

        Move();
    }

    protected override void SetDir()
    {
        _h = Mathf.Sin(Time.time * 5) * 2;
        _v = -1;

        base.SetDir();
    }
}
