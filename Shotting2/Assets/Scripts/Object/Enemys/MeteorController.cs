using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : ObjectBase
{
    public override void Init(float hMax, float vMax)
    {
        base.Init(hMax, vMax);

        _moveSpeed = 30f;

        _curHP = 5;
        _maxHP = _curHP;
        _damage = 5;
    }

    void Start()
    {
        Init(39, 35);

        _h = 0;
        _v = -1;
    }

    void Update()
    {
        Move();
    }
}
