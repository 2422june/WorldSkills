using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_GunController : ItemBase
{
    void Start()
    {
        base.Init();
        _type = Define.Items.Gun;
        _value = 10;
    }

    void Update()
    {
        base.Move();
    }
}
