using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public GameObject timerText;
    public GameObject continueButton;
    public GameObject winText;

    public void LoadLastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowVictoryText()
    {
        timerText.SetActive(false);
        continueButton.SetActive(true);
        winText.SetActive(true);
    }

}
