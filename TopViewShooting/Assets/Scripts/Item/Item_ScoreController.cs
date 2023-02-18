using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ScoreController : ItemBase
{
    void Start()
    {
        base.Init();
        _type = Define.Items.Score;
        _value = 10;
    }

    void Update()
    {
        base.Move();
    }
}