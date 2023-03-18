using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ObjectBase
{
    private float _rot = 60, _h, _v;
    private Vector3 _spawnPos;
    private int _durability, _oil;

    private List<Transform> _bullets = new List<Transform>();

    public override void Init(int hp, int damage)
    {
        base.Init(hp, damage);
        _moveSpeed = 40f;

        _spawnPos = (Vector3.back * 45) + (Vector3.up * 5);
        transform.position = _spawnPos;
    }

    void Start()
    {
        Init(10, 10);
    }


    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        _dir.x = _h;
        _dir.z = _v;

        Move();
        Rotation();
    }

    protected override void Move()
    {
        if ((transform.position.x + _dir.x) > 23 || (transform.position.x + _dir.x) < -23)
        {
            _dir.x = 0;
        }

        if ((transform.position.z + _dir.z) > 20 || (transform.position.z + _dir.z) < -50)
        {
            _dir.z = 0;
        }

        base.Move();
    }

    void Rotation()
    {
        transform.rotation = Quaternion.Euler(Vector3.back * _dir.x * _rot);
    }

    void Shot()
    {
        
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
