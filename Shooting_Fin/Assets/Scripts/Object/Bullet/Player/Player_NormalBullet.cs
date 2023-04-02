using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_NormalBullet : BulletBase
{
    public override void Init(Vector2 dir, int damage)
    {
        base.Init(dir, damage);

        _hArea = new Vector2(-24.5f, 24.5f);
        _vArea = new Vector2(-13.5f, 12.5f);

        _moveSpeed = 35;
    }

    void Update()
    {
        //SetDir();

        if (!isSet)
            return;

        Move();
    }

    private void SetDir()
    {

    }

    protected override void Move()
    {
        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            other.GetComponent<HitableBase>().GetDamage(_damage);
            GetDamage(other.GetComponent<HitableBase>().GetDamage());
        }
    }
}
