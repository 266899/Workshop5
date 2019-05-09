using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FallingPlanets
{
    Mercury = 1,
    Venus = 2,
    Earth = 3,
    Mars = 4,
    Jupiter = 5,
    Saturn = 6,
    Uranus = 7,
    Neptune = 8
}

public class FallingPlanet : MonoBehaviour
{

    [SerializeField] private FallingPlanets planet;
    private static int sequenceNumber;
    public Rigidbody rb;
    public static bool lost;
    public static bool won;
    public AudioSource source;


    private void Awake()

    {
        won = false;
        sequenceNumber = 1; // first planet that can be clicked

        switch (planet) // Falling speed of planets
        {
            case FallingPlanets.Mercury:
                rb.velocity = new Vector3(0, -9f);
                break;

            case FallingPlanets.Mars:
                rb.velocity = new Vector3(0, -8f);
                break;

            case FallingPlanets.Venus:
                rb.velocity = new Vector3(0, -8f);
                break;

            case FallingPlanets.Earth:
                rb.velocity = new Vector3(0, -6f);
                break;

            case FallingPlanets.Neptune:
                rb.velocity = new Vector3(0, -6.5f);
                break;

            case FallingPlanets.Uranus:
                rb.velocity = new Vector3(0, -5f);
                break;

            case FallingPlanets.Saturn:
                rb.velocity = new Vector3(0, -6f);
                break;

            case FallingPlanets.Jupiter:
                rb.velocity = new Vector3(0, -6f);
                break;
        }
    }

    void OnMouseDown()
    {
        if (planet == FallingPlanets.Mercury && sequenceNumber == 1) // Mercury can be clicked 1st
        {
            gameObject.SetActive(false);
            source.Play();
            sequenceNumber++;
        }

        if (planet == FallingPlanets.Mars && sequenceNumber == 2) // Mars can be clicked 2nd
        {
            gameObject.SetActive(false);
            source.Play();
            sequenceNumber++;
        }

        if (planet == FallingPlanets.Venus && sequenceNumber == 3) // Venus can be clicked 3rd
        {
            gameObject.SetActive(false);
            source.Play();
            sequenceNumber++;
        }

        if (planet == FallingPlanets.Earth && sequenceNumber == 4) // Earth can be clicked 4th
        {
            gameObject.SetActive(false);
            source.Play();
            sequenceNumber++;
        }

        if (planet == FallingPlanets.Neptune && sequenceNumber == 5) // Neptune can be clicked 5th
        {
            gameObject.SetActive(false);
            source.Play();
            sequenceNumber++;
        }

        if (planet == FallingPlanets.Uranus && sequenceNumber == 6) // Uranus can be clicked 6th
        {
            gameObject.SetActive(false);
            source.Play();
            sequenceNumber++;
        }

        if (planet == FallingPlanets.Saturn && sequenceNumber == 7) // Saturn can be clicked 7th
        {
            gameObject.SetActive(false);
            source.Play();
            sequenceNumber++;
        }

        if (planet == FallingPlanets.Jupiter && sequenceNumber == 8) // Jupiter can be clicked 8th
        {
            sequenceNumber++;
            source.Play();
            won = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundTrigger"))
        {
            lost = true;
        }
    }
}
