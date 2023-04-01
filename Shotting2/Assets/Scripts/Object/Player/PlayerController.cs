using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ShooterBase
{
    protected float _rot;
    private GameObject boom;

    public override void Init(float hMax, float vMax)
    {
        Managers._player = transform;

        base.Init(hMax, vMax);

        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullets/Player/NormalBullet");
        boom = Resources.Load<GameObject>("Prefabs/Boom");

        _moveSpeed = 40f;
        _rot = 30f;
        _time = 0.1f;

        _curHP = 100;
        _maxHP = _curHP;
        _damage = 5;
    }

    void Start()
    {
        Init(40, 15);
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        
        _timer += Time.deltaTime;

        Move();

        Attack();
    }

    protected override void Attack()
    {
        if (Input.GetKey(KeyCode.Space) && _timer >= _time)
        {
            Shot(Vector3.up);
            _timer = 0;
        }
    }

    protected override void OverHorizontalArea()
    {
        _dir.x = 0;
    }

    protected override void OverVerticalArea()
    {
        if(transform.position.z <= -15 || transform.position.z >= 20)
        {
            _dir.z = 0;
        }
    }

    protected override void Move()
    {
        _dir.x = _h;
        _dir.z = _v;

        CheckArea();
        Rotation();
        _dir = _dir.normalized;

        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }

    private void Rotation()
    {
        transform.rotation = Quaternion.Euler(Vector3.back * _dir.x * _rot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            Hit(other.transform);
    }

    private void Hit(Transform other)
    {
        other.GetComponent<ObjectBase>().GetDamage(_damage);
        GetDamage(other.GetComponent<ObjectBase>().GetDamage());

        Instantiate<GameObject>(boom, transform.position, Quaternion.identity);
    }
}
