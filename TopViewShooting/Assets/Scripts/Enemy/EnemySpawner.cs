using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool _isInGame;

    private void Start()
    {
    }

    void Update()
    {
        
    }

    public void SetSpawnig(bool isCanSpawnig)
    {
        _isInGame = isCanSpawnig;
    }
}
