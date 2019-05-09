using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopTextRotation : MonoBehaviour
{

    public Transform planetText;

    // Update is called once per frame
    void Update()
    {
        planetText.rotation = Quaternion.identity;
    }
}
