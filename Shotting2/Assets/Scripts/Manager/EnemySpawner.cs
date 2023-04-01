using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _enemys = new List<GameObject>();

    [SerializeField]
    private List<spawnInfo> _spawnSequence = new List<spawnInfo>();
    private List<spawnInfo> _destroy = new List<spawnInfo>();
    private GameObject _prefab;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        foreach(spawnInfo info in _spawnSequence)
        {
            if(info.time <= _time)
            {
                Spawn(info);
            }
        }

        DestroyInfo();
    }

    private void Spawn(spawnInfo info)
    {
        _destroy.Add(info);
        _prefab = Instantiate<GameObject>(_enemys[(int)info.type], info.pos, Quaternion.identity);
    }

    private void DestroyInfo()
    {
        foreach (spawnInfo info in _destroy)
        {
            _spawnSequence.Remove(info);
        }
        _destroy.Clear();
    }

    [System.Serializable]
    struct spawnInfo
    {
        public float time;
        public Vector3 pos;
        public Define.Enemys type;
    }
}
