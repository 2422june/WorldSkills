using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyBase : ActorBase
{
    protected Vector3 _originPos;

    protected override void Init()
    {
        base.Init();
        _max.z = 45;
        _min.z = -3;
        _originPos = transform.position;

        _hpBar = transform.Find("Canvas").Find("HPBar").GetComponent<Slider>();
    }

    protected override void Move()
    {
        /*if (IsOverMapXLine())
            _moveDir.x = 0;
        if (IsOverMapZLine())
            _moveDir.z = 0;*/

        transform.position = _moveDir;
    }

    public override void GetDamage(int damage)
    {
        _hp -= damage;
        _hpBar.value = _hp;
        if (_hp <= 0)
        {
            Die();
        }
    }

    public int GetDamage()
    {
        return _damage;
    }

    protected override void Attack()
    {
        _attackTimer = 0;
        Transform bullet = Instantiate(_bullet, _bullet.position, Quaternion.Euler(Vector3.down * 180));
        bullet.GetComponent<EnemyBulletController>().Init(10, _bulletDir);
        bullet.GetComponent<EnemyBulletController>().Shot(_bullet.position);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
