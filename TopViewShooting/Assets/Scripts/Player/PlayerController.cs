using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : ObjectBase
{
    private float _rotValue;
    private Vector3 _rot;

    protected override void Init(int hp, int damage, float moveSpeed)
    {
        base.Init(hp, damage, moveSpeed);
        _rotValue = -40;
    }

    void Start()
    {
        Init(100, 10, 12f);
    }

    void Update()
    {
        SetDirection();
        Movement();
        Rotation();
        
        if(IsShot())
        {
            Shot();
        }
    }

    bool IsShot()
    {
        return (Input.GetKeyDown(KeyCode.Space));
    }

    void Shot()
    {
        GameObject bullet = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/PlayerBullet"), transform.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().Init(10, Vector2.up, _damage);
    }

    void SetDirection()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        _dir.x = _h;
        _dir.z = _v;
        _dir = _dir.normalized;
    }

    void Movement()
    {
        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }

    void Rotation()
    {
        _rot.z = _rotValue * _h;
        transform.rotation = Quaternion.Euler(_rot);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Collect(other.GetComponent<ItemBase>());
            ShowCollectEffect();
        }
    }

    void ShowCollectEffect()
    {
        Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/CollectEffect"), transform.position, Quaternion.identity);
    }

    void Collect(ItemBase item)
    {
        int value = item._value;
        Define.Items type = item.Collect();

        switch(type)
        {
            case Define.Items.Heart:
                Heal(value);
                break;

            case Define.Items.Gun:
                DamageUp(value);
                break;

            case Define.Items.Star:
                MoveSpeedUp(value);
                break;

            case Define.Items.Score:
                GetScore(value);
                break;

            default:
                break;
        }
    }

    void Heal(int value)
    {
        _currentHp += value;
        if (_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
    }

    void DamageUp(int value)
    {
        _damage += value;
    }

    void MoveSpeedUp(int value)
    {
        _moveSpeed += value;
    }

    void GetScore(int value)
    {
        Managers.GameManager._score += value;
    }
}
