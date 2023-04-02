using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBase : ActorBase
{
    protected GameObject _bulletSource;
    protected GameObject _bulletPrefab;
    protected Transform _firePos;

    protected float _attackDelay, _time;

    public override void Init()
    {
        _firePos = transform.Find("FirePos");
    }

    protected virtual void Attack()
    {
    }

    protected virtual void Shot()
    {
    }
}
