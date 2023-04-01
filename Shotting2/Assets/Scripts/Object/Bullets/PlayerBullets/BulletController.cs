using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : BulletBase
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


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            Hit(other.transform);
    }

    private void Hit(Transform other)
    {
        other.GetComponent<ObjectBase>().GetDamage(_damage);
        GetDamage(other.GetComponent<ObjectBase>().GetDamage());

        Instantiate<GameObject>(boom, transform.position, Quaternion.identity);
    }
}
