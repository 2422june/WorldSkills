using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_StarController : ItemBase
{
    void Start()
    {
        base.Init();
        _type = Define.Items.Star;
        _value = 3;
    }

    void Update()
    {
        base.Move();
    }
}