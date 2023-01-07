using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUIBase : MonoBehaviour
{
    protected bool isAwaking = false;

    public virtual void OnShow()
    {
        if (isAwaking)
        {
            return;
        }
        isAwaking = true;
    }
}
