using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private Transform[] _maps = new Transform[3];

    private Transform _firstMap;
    private int _firstIndex;

    private Vector3 _nextPos;
    private Vector3 _originPos;

    private float _moveSpeed;

    private bool isScroll;

    void Start()
    {
        Init();
        Scrollable(true);
    }

    void Init()
    {
        _originPos = new Vector3(0, -10, 30);
        _moveSpeed = 30f;

        for (int i = 0; i < 3; i++)
        {
            _maps[i] = transform.Find($"Map{i+1}");
        }
        _firstIndex = 0;
        _firstMap = _maps[_firstIndex];
        _nextPos = _firstMap.position;

        isScroll = false;
    }

    public void Scrollable(bool iscanScroll)
    {
        isScroll = iscanScroll;
    }

    void Update()
    {
        if (isScroll)
        {
            Scroll();
        }
    }

    void Scroll()
    {
        _nextPos.z = _firstMap.position.z + (_moveSpeed * Time.deltaTime * -1);

        _firstMap.position = _nextPos;
        _maps[(_firstIndex + 1) % _maps.Length].position = _nextPos + (Vector3.forward * 30);
        _maps[(_firstIndex + 2) % _maps.Length].position = _nextPos + (Vector3.forward * 60);

        if (_nextPos.z <= -60)
        {
            _firstMap.position = _originPos;

            _firstIndex = (_firstIndex + 1) % _maps.Length;
            _firstMap = _maps[_firstIndex];
        }
    }
}
