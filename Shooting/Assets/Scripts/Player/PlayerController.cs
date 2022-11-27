using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ActorBase
{

    protected override void Init()
    {
        _hp = 100;
        _damage = 30;
        _moveSpeed = 5;
        _moveDir = Vector3.zero;
        _hpBar.value = _hp;
    }

    void Update()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.z = Input.GetAxisRaw("Vertical");

        Move();
    }

    protected override void Move()
    {

    }

    public override void GetDamage(int damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            Die();
        }
    }

    protected override void Attack()
    {

    }

    protected override void Die()
    {

    }
}
