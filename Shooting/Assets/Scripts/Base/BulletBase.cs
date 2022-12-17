using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    protected bool isShot;
    protected Vector3 _origin;
    protected float _moveSpeed;
    protected float _moveLength;
    protected RaycastHit _hit;
    protected Ray _ray;
    protected int _damage;
    protected Vector3 _bulletDir;

    public void Init(int damage, Vector3 bulletDir, float moveSpeed)
    {
        SetDamage(damage);
        _bulletDir = bulletDir;
        _origin = transform.position;
        isShot = false;
        _moveSpeed = moveSpeed;
    }

    public void Shot(Vector3 pos)
    {
        transform.position = pos;
        isShot = true;
        gameObject.SetActive(true);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    public void ReLoading()
    {
        isShot = false;
        transform.position = _origin;
        gameObject.SetActive(false);
    }

     protected virtual void Fly()
     {
        if (!isShot)
            return;
     }
}
