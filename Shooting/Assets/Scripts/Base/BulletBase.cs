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

    public void Init(int damage)
    {
        SetDamage(damage);
        _origin = transform.position;
        isShot = false;
        _moveSpeed = 95f;
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    public void Shot(Vector3 pos)
    {
        transform.position = pos;
        isShot = true;
        gameObject.SetActive(true);
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
