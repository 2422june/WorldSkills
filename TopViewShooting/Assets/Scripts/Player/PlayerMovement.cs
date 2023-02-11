using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _h, _v, _moveSpeed, _rotValue;
    private Vector3 _dir, _rot;

    void Start()
    {
        _moveSpeed = 12f;
        _rotValue = -40;
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        _dir.x = _h;
        _dir.z = _v;
        _dir = _dir.normalized;

        transform.position += _dir * _moveSpeed * Time.deltaTime;

        _rot.z = _rotValue * _h;
        transform.rotation = Quaternion.Euler(_rot);
    }
}
