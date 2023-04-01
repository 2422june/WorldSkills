using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBase : ObjectBase
{
    protected GameObject _bulletPrefab, _bullet;
    protected Transform _firePos;
    protected float _time, _timer;

    public override void Init(float hMax, float vMax)
    {
        base.Init(hMax, vMax);

        _firePos = transform.Find("FirePos");
    }


    protected virtual void Attack()
    {
        if (_timer >= _time)
        {
            Shot(Vector3.down);
            _timer = 0;
        }
    }

    protected virtual void Shot(Vector3 dir)
    {
        _bullet = Instantiate(_bulletPrefab);
        _bullet.transform.position = _firePos.position;
        _bullet.GetComponent<BulletBase>().Init(dir, _damage);
    }
}
