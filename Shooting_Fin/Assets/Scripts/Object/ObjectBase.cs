using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    protected float _moveSpeed;
    protected Vector3 _dir;

    protected virtual void Move()
    {

    }

    public  virtual void Init()
    {

    }
}
