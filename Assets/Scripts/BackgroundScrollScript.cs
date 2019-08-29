using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollScript : MonoBehaviour
{
    public float Speed = 0f;
    private Renderer _renderer;
    private float _position = 0f;
    private float _positionChange = 0.01f;
    private float _textureWidth;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _textureWidth = gameObject.transform.localScale.x;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        _renderer.material.mainTextureOffset = new Vector2(_position * Speed, 0f);
        _position += _positionChange;
        if (_position > _textureWidth)
        {
            _position = 0;
        }
    }
}
