using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject[] planets;
    public GameObject[] placeholders;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomly();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomly()
    {
        //Fix
        // Random planet spawned around
        for (int i = 0; i < placeholders.Length; i++)
        {
            int randomPlanet = (int)Math.Floor(Random.Range(0f, planets.Length));
            Debug.Log(randomPlanet);
            planets[randomPlanet].transform.position = placeholders[i].transform.position;
            planets[randomPlanet].SetActive(true);
        }
    }
}
