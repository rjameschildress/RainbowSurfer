using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRockHolder : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpaceRockSpawner;
    private float _offsetX;
    private List<SpaceRockSpawner> _spaceRockSpawners = new List<SpaceRockSpawner>();
    private float _playerHeight;
    private int _backgroundHeight = 16;
    private int _numOfSpawners;

    private void Start()
    {
        _offsetX = transform.position.x - Player.transform.position.x;
        _playerHeight = Player.transform.GetComponentInChildren<SpriteRenderer>().bounds.size.y;
        _numOfSpawners = (int)(_backgroundHeight / _playerHeight);
        for (int i = 0; i < _numOfSpawners; i++)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, (_backgroundHeight / 2) - (_playerHeight * i));
            GameObject currSpawner = Instantiate(SpaceRockSpawner, spawnPos, Quaternion.identity, transform);
            _spaceRockSpawners.Add(currSpawner.GetComponent<SpaceRockSpawner>());
        }
        InvokeRepeating("FireARock", 1.5f, 1f);
        InvokeRepeating("FireARock", 2f, 1f);
        InvokeRepeating("FireARock", 2.5f, 1f);
        InvokeRepeating("FireARock", 3f, 1f);
        InvokeRepeating("FireARock", 3.5f, 1f);
        InvokeRepeating("FireARock", 4f, 1f);
    }

    private void FireARock()
    {
        int selected = Random.Range(0, _numOfSpawners);
        if (_spaceRockSpawners[selected].Firing == false)
        {
            _spaceRockSpawners[selected].Fire = true;
        }
        else if (selected == 0 || selected == _numOfSpawners - 1)
        {
            Debug.Log($"Couldn't fire rock at edge: {selected}");
        }
        else if (_spaceRockSpawners[selected + 1].Firing == false)
        {
            _spaceRockSpawners[selected + 1].Fire = true;
        }
        else if (_spaceRockSpawners[selected - 1].Firing == false)
        {
            _spaceRockSpawners[selected - 1].Fire = true;
        }
        else
        {
            Debug.Log("Unable to fire a rock");
        }
    }

    private void FixedUpdate()
    {
        Vector3 currPlayerPosition = new Vector3(Player.transform.position.x, transform.position.y);
        currPlayerPosition.x += _offsetX;
        transform.position = currPlayerPosition;
    }
}
