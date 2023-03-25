using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _curTime;

    public List<enemyInfo> _enemyInfos = new List<enemyInfo>();
    private List<enemyInfo> _spawnedInfos = new List<enemyInfo>();
    private List<GameObject> _enemys = new List<GameObject>();
    private Vector3 _spawnPos;

    void Start()
    {
        _curTime = 0;
        _spawnPos = (Vector3.forward * 300) + (Vector3.up * 5);

        for (int i = 1; i <= System.Enum.GetValues(typeof(enemyType)).Length; i++)
        {
            _enemys.Add(Resources.Load<GameObject>($"Prefabs/Enemys/Enemy{i}"));
        }
    }


    void Update()
    {
        _curTime += Time.deltaTime;

        for(int i = 0; i < _enemyInfos.Count; i++)
        {
            if (_enemyInfos[i].spawnTime <= _curTime)
            {
                Spawn(_enemyInfos[i]);
            }
        }

        foreach (enemyInfo info in _spawnedInfos)
        {
            _enemyInfos.Remove(info);
        }
        _spawnedInfos.Clear();
    }

    void Spawn(enemyInfo info)
    {
        _spawnedInfos.Add(info);

        _spawnPos.x = info.spawnXPos;
        Instantiate<GameObject>(_enemys[(int)info.type], _spawnPos, Quaternion.identity);
    }
}

[System.Serializable]
public struct enemyInfo
{
    public enemyType type;
    public float spawnXPos;
    public float spawnTime;

}

public enum enemyType
{
    normal = 0,
    shooter1
}