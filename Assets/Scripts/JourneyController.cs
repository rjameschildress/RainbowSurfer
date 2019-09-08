using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyController : MonoBehaviour
{
    public Journey CurrentJourney;
    public SpaceRockHolder SpaceRockHolder;
    public GameObject Player;
    public GameObject[] PossibleAsteroidBelts;
    public GameObject UIHolder;
    private bool _shouldCountTime;
    private float _currentTime;
    private float _totalTime;
    private float _offsetX;
    private int _rockIterator;

    // Start is called before the first frame update
    void Start()
    {
        SpaceRockHolder = GameObject.FindGameObjectWithTag("SpaceRockHolder").GetComponent<SpaceRockHolder>();
        _shouldCountTime = true;
        _offsetX = transform.position.x - Player.transform.position.x;
        _currentTime = 0.0f;
        _totalTime = 60f;
        _rockIterator = 0;
    }

    private void Update()
    {
        if (_shouldCountTime)
        {
            _currentTime += Time.fixedDeltaTime;
            UIHolder.GetComponent<UIController>().UpdateTravelProgress(Mathf.Clamp01(_currentTime / _totalTime));
        }

        if (CurrentJourney.TimeForAsteroidBelts.Length > _rockIterator)
        {
            if (_currentTime >= CurrentJourney.TimeForAsteroidBelts[_rockIterator])
            {
                _rockIterator++;
                StartCoroutine(SpawnAsteroidBelt());
            }
        }
    }

    private IEnumerator SpawnAsteroidBelt()
    {
        SpaceRockHolder.ShouldFire = false;
        int selected = Random.Range(0, PossibleAsteroidBelts.Length);
        Instantiate(PossibleAsteroidBelts[selected], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        SpaceRockHolder.ShouldFire = true;
    }

    private void FixedUpdate()
    {
        Vector3 currPlayerPosition = new Vector3(Player.transform.position.x, transform.position.y);
        currPlayerPosition.x += _offsetX;
        transform.position = currPlayerPosition;
    }
}
