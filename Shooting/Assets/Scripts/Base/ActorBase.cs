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


    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {

    }

    protected virtual void Move()
    {

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
