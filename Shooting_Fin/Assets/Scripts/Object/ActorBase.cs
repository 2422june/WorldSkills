using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBase : HitableBase
{
    protected float _h, _v;
    protected Vector2 _hArea, _vArea;

    protected virtual void SetDir()
    {
        _dir.x = _h;
        _dir.z = _v;
        _dir = _dir.normalized;
    }

    protected virtual void CheckArea()
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
