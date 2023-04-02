using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : ShooterBase
{
    private float _oil, _maxOil;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        _hp = 100;
        _maxHp = _hp;

        _oil = 1000;
        _maxOil = _oil;

        _damage = 55;

        _hArea.x = -24.5f;
        _hArea.y = 24.5f;

        _vArea.x = -13.5f;
        _vArea.y = 12.5f;

        _bulletSource = Resources.Load<GameObject>("Prefabs/Bullets/Player/NormalBullet");

        _moveSpeed = 35;
        _attackDelay = 0.2f;
        _time = 0;
    }

    void Update()
    {
        KeyInput();

        SetDir();
        CheckArea();

        Move();

        Attack();

        OilCycle();
    }

    private void OilCycle()
    {
        _oil -= Time.deltaTime;
        Manager.gameManager.SynchPlayerOil((int)_oil);
    }

    private void KeyInput()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
    }

    protected override void SetDir()
    {
        _dir.x = _h;
        _dir.z = _v;
        _dir = _dir.normalized;
    }

    protected override void CheckArea()
    {
        if (_h < 0 && transform.position.x <= _hArea.x)
        {
            _dir.x = 0;
        }

        if (_h > 0 && transform.position.x >= _hArea.y)
        {
            _dir.x = 0;
        }

        if (_v < 0 && transform.position.z <= _vArea.x)
        {
            _dir.z = 0;
        }

        if (_v > 0 && transform.position.z >= _vArea.y)
        {
            _dir.z = 0;
        }
    }

    protected override void Move()
    {
        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }

    protected override void Attack()
    {
        _time += Time.deltaTime;

        //공격 조건 판단
        if (Input.GetKey(KeyCode.Space))
        {
            if (_time >= _attackDelay)
            {
                _time = 0;
                Shot();
            }
        }
    }

    protected override void Shot()
    {
        _bulletPrefab = Instantiate(_bulletSource, _firePos.position, Quaternion.identity);
        _bulletPrefab.GetComponent<BulletBase>().Init(Vector2.up, _damage);
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            other.GetComponent<HitableBase>().GetDamage(_damage);
            GetDamage(other.GetComponent<HitableBase>().GetDamage());
        }
    }

    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        Manager.gameManager.SynchPlayerHP(_hp);
    }
}
