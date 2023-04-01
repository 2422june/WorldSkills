using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Transform Player
    {
        get
        {
            if(_player == null)
            {
                _player = GameObject.Find("Player").transform;
            }
            return _player;
        }

        set
        {

        }

    }
    public static Transform _player;
}
