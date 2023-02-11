using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroller : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private float _scrollSpeed;
    private Vector2 _offset;
      
    void Start()
    {
        _scrollSpeed = -2f;
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        _offset = _meshRenderer.material.mainTextureOffset;
        _offset.y += Time.deltaTime * _scrollSpeed;

        _meshRenderer.material.mainTextureOffset = _offset;
    }
}
