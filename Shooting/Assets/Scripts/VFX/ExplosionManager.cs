using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private static ExplosionManager instance = null;

    public static ExplosionManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.Find("ExplosionManager").GetComponent<ExplosionManager>();
            }
            return instance;
        }

        set
        {

        }
    }

    [SerializeField]
    private Transform _explosion;
    private List<Transform> _explosions = new List<Transform>();
    private int _index = 0;
    private int _max = 30;

    void Start()
    {

        for (_index = 0; _index < _max; _index++)
        {
            _explosions.Add(Instantiate(_explosion, _explosion.position, Quaternion.identity));
            _explosions[_index].gameObject.SetActive(false);
        }
    }

    public void CreateExplosion(Vector3 pos)
    {
        _index = (_index + 1) % _max;
        if (_explosions[_index].gameObject.activeSelf)
        {
            _explosions.Add(Instantiate(_explosion, pos, Quaternion.identity));
            _index = _max - 1;
        }
        _explosions[_index].position = pos;
        _explosions[_index].gameObject.SetActive(true);
        _explosions[_index].GetComponent<ParticleSystem>().Play();
    }
}
