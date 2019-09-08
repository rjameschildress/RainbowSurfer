using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Journey : ScriptableObject
{
    public Sprite LeavingPlanet;
    public Sprite DestinationPlanet;
    public float TravelTime;
    public float[] TimeForAsteroidBelts;
    public float[] TimeForBattles;
}
