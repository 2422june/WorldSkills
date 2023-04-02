using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : HitableBase
{
    protected Vector2 _hArea, _vArea;
    protected bool isSet = false;

    public virtual void Init(Vector2 dir, int damage)
    {
        _dir.x = dir.x;
        _dir.z = dir.y;
        _dir = _dir.normalized;

        _damage = damage;

        transform.LookAt(transform.position + _dir);

        isSet = true;
    }

}
