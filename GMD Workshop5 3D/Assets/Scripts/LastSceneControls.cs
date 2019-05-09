using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastSceneControls : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Start()
    {
        timerText.text = Math.Round(PlayerPrefs.GetFloat("Timer"), 1).ToString();
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
