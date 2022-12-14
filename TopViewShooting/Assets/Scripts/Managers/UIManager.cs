using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : ManagerBase
{
    private Transform _canvas;

    public override void Init()
    {
    }

    public Transform SetCanvas(string name)
    {
        _canvas = GameObject.Find(name).transform;
        if(_canvas == null)
        {
            Debug.Log($"no {name} Object");
        }
        return _canvas;
    }

    public T Find<T>(string objName)
    {
        if(_canvas == null)
        {
            Debug.Log("you don't set canvas");
            return default(T);
        }

        Transform obj = _canvas.Find(objName);
        T btn = obj.GetComponent<T>();
        if(btn == null)
        {
            Debug.Log($"No element in {objName}");
        }
        return btn;
    }
}
