using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorsairController : EnemyBase
{
    protected override void Init()
    {
        base.Init();

        Init(10, 60, 10, 1);

        _bullet = transform.Find("Bullet");
        _attackTime = 1f;
        _bulletDir = Vector3.back;

        _hpBar = transform.Find("Canvas").Find("HPBar").GetComponent<Slider>();
        _hp = 60;
        _hpBar.maxValue = _hp;
        _hpBar.value = _hp;

        _moveDir = Vector3.zero;
        _nextPos = Vector3.zero;
    }

    void Update()
    {
        Move();

        _attackTimer += Time.deltaTime;

        if (_attackTime <= _attackTimer)
        {
            Attack();
        }
    }

    protected override void Move()
    {
        _moveDir.z = transform.position.z - (_moveSpeed * Time.deltaTime);
        _moveDir.x = _originPos.x + (Mathf.Sin(Time.time * 3) * 7);

        transform.position = _moveDir;
    }

    protected override void Attack()
    {
        _attackTimer = 0;
        Transform bullet = Instantiate(_bullet, _bullet.position, Quaternion.Euler(Vector3.down * 180));
        bullet.GetComponent<EnemyBulletController>().Init(_damage, _bulletDir);
        bullet.GetComponent<EnemyBulletController>().Shot(_bullet.position);
    }
}
