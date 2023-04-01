using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal_Bullet : BulletBase
{
    public override void Init(Vector2 dir, int damage)
    {
        base.Init(dir, damage);

        boom = Resources.Load<GameObject>("Prefabs/Boom");
    }

    void Update()
    {
        if (isActive)
        {
            Move();
        }
    }

    protected override void Shot()
    {
        base.Shot();
    }

    protected override void CheckArea()
    {
        base.CheckArea();
    }

    protected override void OverHorizontalArea()
    {
        Destroy(gameObject);
    }

    protected override void OverVerticalArea()
    {
        Destroy(gameObject);
    }

    protected override void Move()
    {
        base.Move();
    }
}
