using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Transform Player
    {
        get
        {
            if (_player == null)
            {
                _player = GameObject.Find("Player").transform;
            }
            return _player;
        }
    }

    public static Transform _player;
    public static GameManager gameManager;
}
