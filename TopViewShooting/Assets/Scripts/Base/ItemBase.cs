using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    // HP, Speed, Score, Damage
    private float _moveSpeed;

    public virtual void Init()
    {
        _moveSpeed = 5;
    }

    void Update()
    {
        transform.position = Vector3.back * _moveSpeed;
        if (transform.position.z <= -6)
        {
            Destroy(gameObject);
        }
    }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
