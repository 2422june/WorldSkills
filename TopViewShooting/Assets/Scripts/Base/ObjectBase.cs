using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    protected float _moveSpeed, _h, _v;
    protected int _currentHp, _maxHp, _damage;
    protected Vector3 _dir;

    protected virtual void Init(int hp, int damage, float moveSpeed)
    {
        _maxHp = hp;
        _currentHp = _maxHp;

        _moveSpeed = moveSpeed;
        _damage = damage;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public void GetDamage(int damage)
    {
        _currentHp -= damage;

        if(IsDie())
        {
            Die();
        }
    }

    public bool IsDie()
    {
        if (_currentHp <= 0)
        {
            _currentHp = 0;
            return true;
        }

        return false;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
