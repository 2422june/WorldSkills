using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetheorSpawner : MonoBehaviour
{
    private float _curTime;
    private GameObject _metheor;
    public List<metheorInfo> _metheorInfos = new List<metheorInfo>();
    private Vector3 _spawnPos;
    private int _index;

    void Start()
    {
        _curTime = 0;
        _spawnPos = (Vector3.forward * 300) + (Vector3.up * 5);
        _metheor = Resources.Load<GameObject>("Prefabs/Enemys/Metheor");
    }


    void Update()
    {
        _curTime += Time.deltaTime;

        if(_index < _metheorInfos.Count)
        {
            if (_metheorInfos[_index].spawnTime <= _curTime)
            {
                Spawn(_metheorInfos[_index]);
                _index++;
            }
        }
    }

    void Spawn(metheorInfo info)
    {
        _spawnPos.x = info.spawnXPos;
        Instantiate<GameObject>(_metheor, _spawnPos, Quaternion.identity);
    }
}

[System.Serializable]
public struct metheorInfo
{
    public float spawnXPos;
    public float spawnTime;
}