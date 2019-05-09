using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    private float time;
    private bool continueTimer;

    private void Start()
    {
        time = PlayerPrefs.GetFloat("Timer");
        continueTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (continueTimer)
        {
            time += Time.deltaTime;
            timerText.text = Math.Round(time, 1).ToString();
        }
    }

    public void StopTimer()
    {
        continueTimer = false;
        PlayerPrefs.SetFloat("Timer", time); // set time 
    }

    public void ResetTimer()
    {
        PlayerPrefs.SetFloat("Timer", 0);
    }

}
