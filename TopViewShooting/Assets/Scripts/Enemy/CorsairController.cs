using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorsairController : EnemyBase
{
    void Start()
    {
        Init(0, 1, 0);// 10);
        SetDir(Vector2.down);
    }


    void Update()
    {
        Move();
    }
}
