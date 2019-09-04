using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSProjectileController : MonoBehaviour
{
    private Vector2 _speed = new Vector2(12, 0);
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private Color32[] _colors = {
        new Color32(255, 0, 0, 255),
        new Color32(255, 127, 0, 255),
        new Color32(255, 255, 0, 255),
        new Color32(0, 255, 0, 255),
        new Color32(0, 0, 255, 255),
        new Color32(75, 0, 130, 255),
        new Color32(148, 0, 211, 255)
    };
    private int _colorIterator;
    private float _colorSwitchTime = 0.5f;
    private float _destroyPosX;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _colorIterator = Random.Range(0, 7);
        _spriteRenderer.color = _colors[_colorIterator];
        InvokeRepeating("ChangeColor", 0.1f, _colorSwitchTime);
        _rb.velocity = _speed;
        _destroyPosX = transform.position.x + 60f;
    }

    private void ChangeColor()
    {
        _colorIterator = _colorIterator == 6 ? 0 : _colorIterator + 1;
        _spriteRenderer.color = _colors[_colorIterator];
    }

    private void FixedUpdate()
    {
        if (transform.position.x >= _destroyPosX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
