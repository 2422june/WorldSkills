using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    protected float _moveSpeed, _h, _v, _hMax, _vMax;
    protected Vector3 _dir;
    protected int _curHP, _maxHP, _damage;

    public virtual void Init(float hMax, float vMax)
    {
        _hMax = hMax;
        _vMax = vMax;
    }

    protected virtual void CheckArea()
    {
        if ((transform.position + _dir).x <= -_hMax || (transform.position + _dir).x >= _hMax)
        {
            OverHorizontalArea();
        }
        if ((transform.position + _dir).z <= -_vMax || (transform.position + _dir).z >= _vMax)
        {
            OverVerticalArea();
        }
    }

    protected virtual void OverHorizontalArea() { }

    protected virtual void OverVerticalArea() { }

    protected virtual void Move()
    {
        _dir.x = _h;
        _dir.z = _v;

        CheckArea();
        _dir = _dir.normalized;

        transform.position += _dir * _moveSpeed * Time.deltaTime;

    }

    public void GetDamage(int damage)
    {
        _curHP -= damage;
        if (_curHP <= 0)
        {
            Die();
        }
    }

    public int GetDamage()
    {
        return _damage;
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
