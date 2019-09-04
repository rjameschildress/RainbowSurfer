using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("RainbowSurfer");
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(Random.Range(1f, 2f), 0f);
    }

    private void FixedUpdate()
    {
        if (_player.transform.position.x >= transform.position.x + 4f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
