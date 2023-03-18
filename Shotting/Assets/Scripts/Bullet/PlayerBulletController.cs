using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : ObjectBase
{
    void Start()
    {
        Init(1, 5);
    }

    public override void Init(int hp, int damage)
    {
        base.Init(hp, damage);
        _moveSpeed = 80f;
        _dir = Vector3.forward;
    }

    void Update()
    {
        Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            //GetDamage(other.transform.);
        }
        if (other.transform.CompareTag("EnemyBullet"))
        {
            //GetDamage(other.transform.);
        }
        if (other.transform.CompareTag("Metheor"))
        {
            GetDamage(other.transform.GetComponent<EnemyBase>().GetDamage());
            other.transform.GetComponent<EnemyBase>().GetDamage(_damage);
        }
    }
}
