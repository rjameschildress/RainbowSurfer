using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject Projectile;
    private int _projToFire = 3;
    private float _chargeTime = 3f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _projToFire >= 1)
        {
            Vector3 spawnPos = new Vector3(transform.position.x + 0.3f, transform.position.y);
            FireProjectile(spawnPos);
            _projToFire--;
        }
    }

    void FireProjectile(Vector3 spawnPos)
    {
        Instantiate(Projectile, spawnPos, Quaternion.identity);
        // TODO: Deplete UI Element
        StartCoroutine(Charge());
    }

    IEnumerator Charge()
    {
        for (float i = 0f; i < _chargeTime; i += Time.fixedDeltaTime)
        {
            // TODO: Fill up UI element
            yield return null;
        }

        _projToFire++;
    }
}
