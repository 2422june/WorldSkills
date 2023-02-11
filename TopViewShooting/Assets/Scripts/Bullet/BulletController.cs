using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _moveSpeed;
    private Vector3 _dir;
    private int _damage;

    public void Init(float moveSpeed, Vector2 dir, int damage)
    {
        _moveSpeed = moveSpeed;
        _dir.x = dir.x;
        _dir.z = dir.y;
        _damage = damage;
    }


    void Update()
    {
        transform.position += _dir * _moveSpeed * Time.deltaTime;

        if(transform.position.z >= 6)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ShowExplosion();
            other.GetComponent<ObjectBase>().GetDamage(_damage);

            Destroy(gameObject);
        }
        else if (other.CompareTag("EnemyBullet"))
        {
            ShowExplosion();
            Destroy(other.gameObject);
        }
    }

    void ShowExplosion()
    {
        Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Explosion"), transform.position, Quaternion.identity);
    }
}
