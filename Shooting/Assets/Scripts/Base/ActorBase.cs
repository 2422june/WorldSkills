using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorBase : MonoBehaviour
{
    protected int _hp;
    protected int _damage;
    protected float _moveSpeed;
    [SerializeField]
    protected float _attackTime;
    [SerializeField]
    protected float _attackTimer;
    protected Vector3 _moveDir;
    [SerializeField]
    protected Slider _hpBar;

    protected Vector3 _max;
    protected Vector3 _min;
    protected Vector3 _nextPos;

    [SerializeField]
    protected Transform _bullet;
    protected Vector3 _bulletDir;


    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        _max.x = 34;
        _max.z = 31;
        _min.x = -34;
        _min.z = -1.75f;

        _attackTime = 0;
        _attackTimer = 0;
    }

    protected void Init(float moveSpeed, int hp, int damage, float attackTime)
    {
        _moveSpeed = moveSpeed;

        _hpBar = transform.Find("Canvas").Find("HPBar").GetComponent<Slider>();

        _attackTime = attackTime;

        _hp = hp;
        _hpBar.maxValue = _hp;
        _hpBar.value = _hp;

        _damage = damage;

        _moveDir = Vector3.zero;
        _nextPos = Vector3.zero;
    }

    protected void BulletSetting(Vector3 bulletDir)
    {
        _bullet = transform.Find("Bullet");
        _bulletDir = bulletDir;
    }

    protected virtual void Move()
    {

    }

    protected virtual bool IsOverMapXLine()
    {
        _nextPos.x = transform.position.x + _moveDir.x;
        return (_nextPos.x >= _max.x) || (_nextPos.x <= _min.x);
    }

    protected virtual bool IsOverMapZLine()
    {
        _nextPos.z = transform.position.z + _moveDir.z;
        return (_nextPos.z >= _max.z) || (_nextPos.z <= _min.z);
    }

    public virtual void GetDamage(int damage)
    {

    }

    protected virtual void Attack()
    {

    }

    protected virtual void Die()
    {

    }
}
