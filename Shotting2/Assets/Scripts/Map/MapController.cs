using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private Transform[] Maps = new Transform[3];
    private Transform _thirdTile;
    private float _moveSpeed;
    private int _thirdIndex;

    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            Maps[i] = transform.Find($"Map{i+1}");
        }
        _thirdIndex = 2;
        _thirdTile = Maps[_thirdIndex];
    }

    void Update()
    {
        _moveSpeed = 90 * Time.deltaTime;

        _thirdTile.position += Vector3.back * _moveSpeed;

        if (_thirdTile.position.z <= -180)
        {
            _thirdTile.position = Vector3.forward * 90;

            _thirdIndex = (_thirdIndex + 2) % Maps.Length;
            _thirdTile = Maps[_thirdIndex];
        }

        Maps[(_thirdIndex + 1) % Maps.Length].position = _thirdTile.position + (Vector3.forward * 90);
        Maps[(_thirdIndex + 2) % Maps.Length].position = _thirdTile.position + (Vector3.forward * 180);
    }
}
