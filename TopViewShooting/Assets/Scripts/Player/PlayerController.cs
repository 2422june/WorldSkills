using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : ObjectBase
{
    private float _rotValue;
    private Vector3 _rot;
    private bool isDie = false;

    protected override void Init(int hp, int damage, float moveSpeed)
    {
        GetComponent<MeshRenderer>().enabled = true;

        base.Init(hp, damage, moveSpeed);

        _rotValue = -40;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);

        isDie = false;
    }

    public void Play()
    {
        Init(3, 10, 12f);
    }

    void Update()
    {
        if (isDie) { return; }

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

        if (transform.position.x * _h >= 7.5f)
        {
            _h = 0;
        }
        if (transform.position.z * _v >= 4)
        {
            _v = 0;
        }

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
        if (isDie) { return; }

        if (other.CompareTag("Item"))
        {
            Collect(other.GetComponent<ItemBase>());
            ShowCollectEffect();
        }
        else if (other.CompareTag("Enemy"))
        {
            ShowExplosion();
            GetDamage(other.GetComponent<ObjectBase>().GetDamage());

            Destroy(other.gameObject);
        }
    }

    protected override void Die()
    {
        if (isDie) { return; }

        //Destroy(gameObject);
        GetComponent<MeshRenderer>().enabled = false;
        isDie = true;
        Invoke("GoToResult", 2);
    }

    void GoToResult()
    {
        if (!Managers.GameManager._isInGame) { return; }

        Managers.SceneManager.LoadScene(Define.Scenes.Result);
        Managers.GameManager._isInGame = false;
    }

    void ShowExplosion()
    {
        Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Explosion"), transform.position, Quaternion.identity);
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
        _canvas.SetHPBar(_currentHp);
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
        Managers.GameManager.AddScore(value);
    }
}
