using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VikingController : EnemyBase
{

    protected override void Init()
    {
        base.Init();

        Init(10, 60, 10, 1);
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

        transform.position = _moveDir;
    }

    protected override void Attack()
    {
        _attackTimer = 0;
        Transform bullet = Instantiate(_bullet, _bullet.position, Quaternion.Euler(Vector3.down * 180));
        bullet.GetComponent<EnemyBulletController>().Init(_damage, _bulletDir, _bullet.position + Vector3.left);

        Transform bullet2 = Instantiate(_bullet, _bullet.position, Quaternion.Euler(Vector3.down * 180));
        bullet2.GetComponent<EnemyBulletController>().Init(_damage, _bulletDir, _bullet.position + Vector3.right);
    }
}
