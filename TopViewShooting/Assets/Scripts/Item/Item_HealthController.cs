using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_HealthController : ItemBase
{
    void Start()
    {
        base.Init();
        _type = Define.Items.Heart;
        _value = 15;
    }

    void Update()
    {
        base.Move();
    }
}