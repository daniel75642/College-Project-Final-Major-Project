using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamp : MonoBehaviour
{
    public Loadsystem ls;

    public void Awake()
    {
        ls = GetComponent<Loadsystem>();
        StartCoroutine(ls.LoadUnload());
    }
}
