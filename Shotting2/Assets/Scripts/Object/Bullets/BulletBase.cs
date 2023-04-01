using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class BulletBase : ObjectBase
{
    protected GameObject boom;

    public virtual void Init(Vector2 dir, int damage)
    {
        base.Init(50, 30);

        _h = dir.x;
        _v = dir.y;

        _moveSpeed = 70f;
        _damage = damage;

        _dir.x = _h;
        _dir.z = _v;
        _dir = _dir.normalized;

        isActive = true;
    }

    public bool isActive;

    protected virtual void Shot()
    {
        isActive = true;
    }
}
