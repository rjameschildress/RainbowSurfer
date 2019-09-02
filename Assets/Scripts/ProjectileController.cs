using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject Projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = new Vector3(transform.position.x + 0.2f, transform.position.y);
            FireProjectile(spawnPos);
        }
    }

    void FireProjectile(Vector3 spawnPos)
    {
        Instantiate(Projectile, spawnPos, Quaternion.identity);
    }
}
