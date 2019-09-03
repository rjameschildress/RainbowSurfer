using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRockSpawner : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpaceRock;
    public bool Fire = false;
    private bool _firing = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Fire && !_firing)
        {
            _firing = true;
            StartCoroutine(FireRock());
        }
    }

    IEnumerator FireRock()
    {
        Instantiate(SpaceRock, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(2f);
        _firing = false;
        Fire = false;
    }
}
