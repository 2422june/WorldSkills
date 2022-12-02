using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private bool isShot;
    private Vector3 _origin;
    private float _moveSpeed;
    private RaycastHit _hit;
    private Ray _ray;
    private int _damage;

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

    void Update()
    {
        if (!isShot)
            return;

        transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;

        _ray.origin = transform.position;
        _ray.direction = Vector3.forward;
        
        if(Physics.Raycast(_ray, out _hit, _moveSpeed * Time.deltaTime, 1<<3))
        {
            transform.position = _hit.point;
            _hit.transform.GetComponent<ActorBase>().GetDamage(_damage);
            ReLoading();
        }

        if(transform.position.z >= 40)
        {
            ReLoading();
        }
    }
}
