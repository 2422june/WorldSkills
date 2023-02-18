using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ObjectBase
{
    void Start()
    {
        _h = 0;
        _v = -1;
        _moveSpeed = 0;// 12f;
    }

    void Update()
    {
        _dir.x = _h;
        _dir.z = _v;
        _dir = _dir.normalized;

        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }

    protected override void Die()
    {
        DropItem();

        base.Die();
    }

    void DropItem()
    {
        int item = Random.Range(0, System.Enum.GetValues(typeof(Define.Items)).Length);
        string objName = "";

        if(item >= System.Enum.GetValues(typeof(Define.Items)).Length)
        {
            return;
        }

        switch((Define.Items)item)
        {
            case Define.Items.Heart:
                objName = "HealthPlusRed";
                break;

            case Define.Items.Gun:
                objName = "Gun1";
                break;

            case Define.Items.Star:
                objName = "Star";
                break;

            case Define.Items.Score:
                objName = "CoinGold";
                break;
        }

        Instantiate<GameObject>(Resources.Load<GameObject>($"Prefabs/Items/{objName}"), transform.position, Quaternion.identity);
    }
}
