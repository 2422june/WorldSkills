using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : ShooterBase
{
    protected void Start()
    {
        Init();
    }

    protected override void Move()
    {
        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }

    protected override void CheckArea()
    {
        if (_h < 0 && transform.position.x <= _hArea.x)
        {
            _dir.x = 0;
        }

        if (_h > 0 && transform.position.x >= _hArea.y)
        {
            _dir.x = 0;
        }

        if (_v < 0 && transform.position.z <= _vArea.x)
        {
            _dir.z = 0;
        }

        if (_v > 0 && transform.position.z >= _vArea.y)
        {
            _dir.z = 0;
        }
    }
}
