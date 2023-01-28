using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _h, _v, _moveSpeed;
    private Vector3 _dir, _moveDir;

    void Start()
    {
        _moveSpeed = 100f;
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        _dir.x = _h;
        _dir.z = _v;

        transform.position += _dir.normalized * _moveSpeed * Time.deltaTime;
    }
}
