using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private MeshRenderer _mesh;
    private Material _mate;

    private float _scrollSpeed;
    private Vector2 _scrollDir;

    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();

        _mate = _mesh.material;
        _scrollSpeed = 2f;
        _scrollDir = Vector3.down * _scrollSpeed;
    }

    void Update()
    {
        _mate.mainTextureOffset += _scrollDir * Time.deltaTime;
    }

    public void SetScrollDir(Vector2 dir)
    {
        _scrollDir = dir;
    }

    public void SetScrollSpeed(float speed)
    {
        _scrollSpeed = speed;
    }
}
