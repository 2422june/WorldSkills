using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkle_EnemyController : ObjectBase
{
    public override void Init(float hMax, float vMax)
    {
        base.Init(hMax, vMax);

        _moveSpeed = 20f;

        _curHP = 5;
        _maxHP = _curHP;
        _damage = 1;
    }

    void Start()
    {
        Init(39, 35);

        _h = (Managers.Player.position - transform.position).x;
        _v = (Managers.Player.position - transform.position).z;
    }

    void Update()
    {
        Move();
    }

    protected override void OverHorizontalArea()
    {
        _h = (Managers._player.position - transform.position).x;
    }
}
