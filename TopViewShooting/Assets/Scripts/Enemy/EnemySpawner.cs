using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool _isInGame;
    private float _time;
    private int _timer;
    private int _type;
    private string _name;
    private int x;
    private Vector3 spawnPos;

    private string[] _path = { "Corsair" };

    void Start()
    {
        Init();
    }

    void Update()
    {
        if(!_isInGame) { return; }

        if(_time + _timer <= Managers.GameManager._time)
        {
            _time = Managers.GameManager._time;
            _timer = 0;

            _type = Random.Range(0, System.Enum.GetValues(typeof(Define.Enemys)).Length - 1);

            x = Random.Range(-8, 8);
            spawnPos.x = x;

            _name = _path[_type];
            Instantiate<GameObject>(Resources.Load<GameObject>($"Prefabs/Enemys/{_name}"), spawnPos, Quaternion.identity);
        
            _timer = Random.Range(1, 3);
        }
    }

    public void SetSpawnig()
    {
        _isInGame = Managers.GameManager._isInGame;
        Init();
    }

    void Init()
    {

        _time = 0;
        _timer = 0;
        _type = 0;
        x = 0;

        spawnPos = Vector3.forward * 6;
    }
}
