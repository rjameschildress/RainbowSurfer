using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Health = 7;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var surfControl = gameObject.GetComponent<SurfController>();
        surfControl.ConstantSpeed = 0f;
        surfControl.SurfSpeed = 0f;

        var sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.enabled = false;
        }

        var trails = gameObject.GetComponentsInChildren<TrailRenderer>();
        foreach (TrailRenderer trail in trails)
        {
            trail.enabled = false;
        }

        var rockSpawners = GameObject.FindGameObjectsWithTag("SpaceRockHolder");
        foreach (GameObject spawner in rockSpawners)
        {
            Destroy(spawner);
        }
    }
}
