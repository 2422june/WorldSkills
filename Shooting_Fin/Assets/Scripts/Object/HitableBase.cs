using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableBase : ObjectBase
{
    protected int _hp, _maxHp;
    protected int _damage;

    public virtual void GetDamage(int damage)
    {
        _hp -= damage;

        if(_hp <= 0)
        {
            _hp = 0;
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }

    public int GetDamage()
    {
        return _damage;
    }
}
