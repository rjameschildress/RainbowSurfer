using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRockSpawner : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpaceRock;
    public bool Fire = false;
    public bool Firing = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Fire && !Firing)
        {
            Firing = true;
            StartCoroutine(FireRock());
        }
    }

    IEnumerator FireRock()
    {
        Instantiate(SpaceRock, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(2f);
        Firing = false;
        Fire = false;
    }
}
