using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCoordinates : MonoBehaviour
{
    public int col, row;

    public void Start()
    {
        this.name = $"{col}, {row}";
    }
}

