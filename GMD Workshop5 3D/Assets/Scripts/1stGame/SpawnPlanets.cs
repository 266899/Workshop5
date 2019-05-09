using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlanets : MonoBehaviour
{

    public List<GameObject> planets;
    public List<GameObject> placeholders;

    void Start()
    {
        SpawnRandomly();
    }

    void SpawnRandomly()
    {

        // Random planet spawned around in random places
        for (int i = 0; i < placeholders.Count; i++)
        {
            int randomPlanet = (int)Math.Floor(Random.Range(0f, planets.Count));
            planets[randomPlanet].transform.position = placeholders[i].transform.position;
            planets[randomPlanet].SetActive(true);
            planets.RemoveAt(randomPlanet);
        }
    }
}
