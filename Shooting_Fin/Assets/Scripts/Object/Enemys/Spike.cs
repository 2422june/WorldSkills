using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : EnemyBase
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

        _moveSpeed = 15;
        
        _h = Manager.Player.position.x - transform.position.x;
        _v = Manager.Player.position.z - transform.position.z;
        SetDir();
    }

    void Update()
    {
        CheckArea();

        Move();
    }
}