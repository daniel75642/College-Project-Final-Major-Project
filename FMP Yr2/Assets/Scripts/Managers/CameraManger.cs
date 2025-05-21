using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManger : MonoBehaviour
{
    [SerializeField] Camera[] cameras;
    public void ChangeToForest()
    {
        cameras[1].targetDisplay = 0;
        cameras[0].targetDisplay = 1;
    }

    public void ChangeToWasteland()
    {
        cameras[2].targetDisplay = 0;
        cameras[0].targetDisplay = 1;
    }
    public void ChangeToToxic()
    {
        cameras[3].targetDisplay = 0;
        cameras[0].targetDisplay = 1;
    }
    public void ChangeBack()
    {
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].targetDisplay = i;
        }
        cameras[0].targetDisplay = 0;
    }

}
