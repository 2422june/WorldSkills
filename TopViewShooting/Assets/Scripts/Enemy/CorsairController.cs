using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorsairController : EnemyBase
{
    void Start()
    {
        Init(15, 1, 5);
        SetDir(Vector2.down);
    }


    void Update()
    {
        Move();
    }
}
