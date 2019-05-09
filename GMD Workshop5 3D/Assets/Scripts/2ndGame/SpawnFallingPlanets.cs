using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnFallingPlanets : MonoBehaviour
{
    public List<GameObject> spawnPlaces;
    public List<GameObject> planets;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < spawnPlaces.Count; i++)
        {
            int randomPlanet = (int)Math.Floor(Random.Range(0f, planets.Count));
            planets[randomPlanet].transform.position = spawnPlaces[i].transform.position;
            planets[randomPlanet].SetActive(true);
            planets.RemoveAt(randomPlanet);
        }

        yield return null;
    }
}
