using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CorrectPlanetSequence : MonoBehaviour
{
    public Planet planetScript;
    public GameObject victoryText;
    public GameObject nextButton;
    public AudioManager audioManager;
    private bool showOnce = false;
    public Timer timer;

    private void Start()
    {
        nextButton.SetActive(false);
        victoryText.SetActive(false);
        showOnce = false;
        planetScript.ResetCorrectSelections();

    }

    void Update()
    {
        if (Planet.correctSelections == 9 && !showOnce)
        {
            StartCoroutine(ShowVictoryScreen());
        }
    }

    IEnumerator ShowVictoryScreen()
    {
        nextButton.SetActive(true);
        victoryText.SetActive(true);
        showOnce = true;
        audioManager.Play("WinSound");
        timer.StopTimer();
        yield return null;
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
