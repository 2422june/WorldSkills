using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ObjectBase
{
    void Start()
    {
        _h = 0;
        _v = -1;
        _moveSpeed = 0;// 12f;
    }

    void Update()
    {
        _dir.x = _h;
        _dir.z = _v;
        _dir = _dir.normalized;

        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }
}
