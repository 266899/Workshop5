using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetVolume : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Volume");
    }
}
