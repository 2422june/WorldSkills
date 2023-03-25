using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerBase
{
    private float _rot = 60, _h, _v;
    private Vector3 _spawnPos;
    private int _durability, _oil;
    private int _index;

    private List<PlayerBulletController> _bullets = new List<PlayerBulletController>();
    private Transform _bulletPos;
    private GameObject _bulletPrefab;

    public override void Init(int hp, int damage)
    {
        base.Init(hp, damage);
        _moveSpeed = 40f;
        _damage = 20;

        _spawnPos = (Vector3.back * 45) + (Vector3.up * 5);
        transform.position = _spawnPos;

        _bulletPos = GameObject.Find("BulletPos").transform;

        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        for (int i = 0; i < 10; i++)
        {
            _bullets.Add(Instantiate<GameObject>(_bulletPrefab).GetComponent<PlayerBulletController>());
            _bullets[i].Init(_bulletPos);
        }
        _index = 0;
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
        Shot();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_bullets[_index]._isShotting)
            {
                _bullets.Add(Instantiate<GameObject>(_bulletPrefab).GetComponent<PlayerBulletController>());
                _index = _bullets.Count - 1;
                _bullets[_index].Init(_bulletPos);
            }
            _bullets[_index].shot(_damage);
            _index = (_index + 1) % _bullets.Count;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GetDamage(other);
    }

    public override void Clear()
    {

    }
}
