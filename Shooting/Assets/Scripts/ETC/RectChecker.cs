using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectChecker : MonoBehaviour
{
    private Vector2 _max;
    private Vector2 _min;

    private Vector4 _Max
    {
        get
        {
            if (_max == Vector2.zero)
            {
                _max.x = 14;
                _max.y = 15;
            }
            return _max;
        }
    }

    private Vector4 _Min
    {
        get
        {
            if (_min == Vector2.zero)
            {
                _min.x = -14;
                _min.y = -1.75f;
            }
            return _min;
        }
    }

    public bool IsInMap(Vector3 pos)
    {
        return ( (pos.x < _Max.x) && (pos.x > _Min.x) && (pos.z < _Max.y) && (pos.z > _Min.y) );
    }
}
