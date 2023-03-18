using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Material _material;
    private float _scrollSpeed;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _material = _meshRenderer.material;
        _scrollSpeed = 1f;
    }

    void Update()
    {
        _material.mainTextureOffset = _material.mainTextureOffset + (Vector2.down * _scrollSpeed * Time.deltaTime);
    }
}
