using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost : MonoBehaviour
{
    public GameObject lostText;
    public GameObject retryButton;
    public GameObject timerText;
    public GameObject resetButton;
    private bool showOnce = false;
    public Timer timer;

    private void Start()
    {
        retryButton.SetActive(false);
        lostText.SetActive(false);
        timerText.SetActive(true);
        resetButton.SetActive(false);
        FallingPlanet.lost = false;
    }

    void Update()
    {
        if (FallingPlanet.lost && !showOnce)
        {
            StartCoroutine(ShowRetryScreen());
        }
    }

    IEnumerator ShowRetryScreen()
    {
        timer.StopTimer();
        lostText.SetActive(true);
        showOnce = true;
        retryButton.SetActive(true);
        timerText.SetActive(false);
        resetButton.SetActive(true);
        //audioManager.Play("LoseSound");
        yield return null;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        retryButton.SetActive(false);
        lostText.SetActive(false);
        timerText.SetActive(true);
        resetButton.SetActive(false);
        FallingPlanet.lost = false;
    }

    public void Reset()
    {
        SceneManager.LoadScene(1);
    }

}
