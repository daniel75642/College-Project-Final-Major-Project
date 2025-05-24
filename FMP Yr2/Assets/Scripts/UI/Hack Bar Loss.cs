using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackBarLoss : MonoBehaviour
{
    public Slider hackBar;

    public Canvas lossScreen;

    public void Update()
    {
        if (hackBar.value >= hackBar.maxValue)
        {
            lossScreen.enabled = true;
        }
    }
}
