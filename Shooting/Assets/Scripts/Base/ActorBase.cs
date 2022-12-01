using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorBase : MonoBehaviour
{
    protected int _hp;
    protected int _damage;
    protected float _moveSpeed;
    protected Vector3 _moveDir;
    [SerializeField]
    protected Slider _hpBar;

    private Vector3 _max;
    private Vector3 _min;
    private Vector3 _nextPos;


    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        _max.x = 34;
        _max.z = 31;
        _min.x = -34;
        _min.z = -1.75f;
    }

    protected virtual void Move()
    {

    }

    protected virtual bool IsOverMapXLine()
    {
        _nextPos.x = transform.position.x + _moveDir.x;
        return (_nextPos.x >= _max.x) || (_nextPos.x <= _min.x);
    }

    protected virtual bool IsOverMapZLine()
    {
        _nextPos.z = transform.position.z + _moveDir.z;
        return (_nextPos.z >= _max.z) || (_nextPos.z <= _min.z);
    }

    public virtual void GetDamage(int damage)
    {

    }

    protected virtual void Attack()
    {

    }

    protected virtual void Die()
    {

    }
}
