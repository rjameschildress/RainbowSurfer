using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundContoller : MonoBehaviour
{
	public GameObject Background;
	public GameObject Player;
    private List<GameObject> _backgrounds = new List<GameObject>();
    private Vector3 spawnPos;
    private float _distanceX = 16f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(5.5f, 0f);
        _backgrounds.Add(Instantiate(Background, spawnPos, Quaternion.identity, transform));
        spawnPos.x += _distanceX;
        _backgrounds.Add(Instantiate(Background, spawnPos, Quaternion.identity, transform));
        spawnPos.x += _distanceX;
        _backgrounds.Add(Instantiate(Background, spawnPos, Quaternion.identity, transform));
        spawnPos.x += _distanceX;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x >= _backgrounds[0].transform.position.x + _distanceX)
        {
            _backgrounds.Add(Instantiate(Background, spawnPos, Quaternion.identity, transform));
            spawnPos.x += _distanceX;

            GameObject toDel = _backgrounds[0];
            _backgrounds.Remove(toDel);
            Destroy(toDel);
        }
    }
}
