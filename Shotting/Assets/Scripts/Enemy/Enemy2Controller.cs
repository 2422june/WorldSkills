using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : EnemyBase
{
    void Start()
    {
        Init(1, 5);
    }

    public override void Init(int hp, int damage)
    {
        base.Init(hp, damage);
        _moveSpeed = 80f;
        _dir = Vector3.back;
    }

    void Update()
    {
        Move();
    }
}
