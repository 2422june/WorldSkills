using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObj : MonoBehaviour
{
    void Start()
    {
        Invoke("TurnOff", 1.5f);
    }

    
    void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
