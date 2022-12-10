using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : BulletBase
{
    private Vector3 _bulletDir;

    public void Init(int damage, Vector3 bulletDir)
    {
        Init(damage);
        _bulletDir = bulletDir;
    }

    void Update()
    {
        Fly();
    }

    protected override void Fly()
    {
        base.Fly();

        _moveLength = _moveSpeed * Time.deltaTime;
        transform.position += _bulletDir * _moveLength;

        _ray.origin = transform.position;
        _ray.direction = Vector3.forward;


        if (Physics.Raycast(_ray, out _hit, _moveLength, 1 << 6))
        {
            transform.position = _hit.point;
            _hit.transform.GetComponent<ActorBase>().GetDamage(_damage);
            ExplosionManager.Instance.CreateExplosion(_hit.point);
            ReLoading();
        }

        if (transform.position.z >= 40)
        {
            ReLoading();
        }
    }
}
