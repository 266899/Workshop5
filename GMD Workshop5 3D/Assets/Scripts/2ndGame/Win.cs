using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Timer timer;
    public GameObject continueButton;
    public GameObject winText;
    public GameObject timerText;
    private bool showOnce = false;

    void Update()
    {
        if (FallingPlanet.won && !showOnce)
        {
            StartCoroutine(ShowContinueScreen());
        }
    }

    IEnumerator ShowContinueScreen()
    {
        timer.StopTimer();
        winText.SetActive(true);
        showOnce = true;
        continueButton.SetActive(true);
        timerText.SetActive(false);
        yield return null;
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load next scene
    }
}
