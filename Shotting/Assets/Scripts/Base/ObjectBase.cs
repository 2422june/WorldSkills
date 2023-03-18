using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    protected float _moveSpeed = 80f;
    protected Vector3 _dir = Vector3.back;
    protected int _hp, _maxHp, _damage;
    public bool _isDie;

    public virtual void Init(int hp, int damage)
    {
        _isDie = false;
        _hp = _maxHp = hp;
        _damage = damage;
    }

    protected virtual void Move()
    {
        transform.position += _dir.normalized * _moveSpeed * Time.deltaTime;
    }

    public  virtual void GetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            _hp = 0;
            Die();
        }
    }
    public virtual int GetDamage()
    {
        return _damage;
    }

    protected virtual void Die()
    {
        _isDie = true;
        gameObject.SetActive(false);
    }
}
