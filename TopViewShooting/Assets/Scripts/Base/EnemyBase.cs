using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : ObjectBase
{
    protected override void Init(int hp, int damage, float moveSpeed)
    {
        base.Init(hp, damage, moveSpeed);
    }

    protected void SetDir(Vector2 dir)
    {
        _h = dir.x;
        _v = dir.y;
    }

    protected virtual void Move()
    {
        _dir.x = _h;
        _dir.z = _v;
        _dir = _dir.normalized;

        transform.position += _dir * _moveSpeed * Time.deltaTime;
        
        if (transform.position.z <= -8)
        {
            Destroy(gameObject);
        }
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

        if (item >= System.Enum.GetValues(typeof(Define.Items)).Length)
        {
            return;
        }

        switch ((Define.Items)item)
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
