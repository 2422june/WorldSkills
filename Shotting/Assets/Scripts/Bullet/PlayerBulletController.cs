using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : PlayerBase
{
    public bool _isShotting;
    private Transform _shotPos;

    public void Init(Transform shotPos)
    {
        _shotPos = shotPos;
        _moveSpeed = 80f;
        _dir = Vector3.forward;
        _isShotting = false;
        gameObject.SetActive(false);
    }

    public void shot(int damage)
    {
        Init(0, damage);
        transform.position = _shotPos.position;
        _isShotting = true;
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (_isShotting)
            Move();
    }

    void OnTriggerEnter(Collider other)
    {
        GetDamage(other);
    }

    public override void Clear()
    {
        gameObject.SetActive(false);
        transform.position = _shotPos.position;
        _isShotting = false;
    }
}
