using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RusherController : EnemyBase
{
    protected override void Init()
    {
        base.Init();

        _moveSpeed = 30f;

        _hp = 60;
        _hpBar.maxValue = _hp;
        _hpBar.value = _hp;

        _nextPos = Vector3.zero;

        Transform player = GameObject.Find("PlayerModel").transform;
        _moveDir = (player.position - transform.position).normalized;
        transform.LookAt(player);
    }

    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.position += _moveDir * _moveSpeed *  Time.deltaTime;
    }
}