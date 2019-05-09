using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimerAtStart : MonoBehaviour
{
    public Timer timer;

    void Start()
    {
        timer.ResetTimer();
    }

}
