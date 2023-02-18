using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    // HP, Speed, Score, Damage
    protected float _moveSpeed;
    public int _value;
    protected Define.Items _type;

    protected void Init()
    {
        _moveSpeed = 5;
        _value = 0;
    }

    protected void Move()
    {
        transform.position += (Vector3.back * _moveSpeed) * Time.deltaTime;
        if (transform.position.z <= -6)
        {
            Destroy(gameObject);
        }
    }

    public virtual Define.Items Collect()
    {
        Destroy(gameObject);
        return _type;
    }
}
