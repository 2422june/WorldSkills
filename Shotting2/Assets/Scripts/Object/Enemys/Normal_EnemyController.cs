using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_EnemyController : EnemyBase
{
    public override void Init(float hMax, float vMax)
    {
        base.Init(hMax, vMax);

        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullets/Enemy/NormalBullet");

        _moveSpeed = 20f;
        _time = 0.5f;

        _curHP = 5;
        _maxHP = _curHP;
        _damage = 1;
    }

    void Start()
    {
        Init(39, 35);

        _h = 0;
        _v = -1;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        Move();

        Attack();
    }

    protected override void OverHorizontalArea()
    {
        _h = 0;
    }
}
