using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public bool _useTimer = true;
    private ParticleSystem _particle;

    void OnAble()
    {
        
    }

    void Start()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(!_useTimer)
        {
            if(_particle.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }
}
