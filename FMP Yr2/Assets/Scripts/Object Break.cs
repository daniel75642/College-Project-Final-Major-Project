using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBreak : MonoBehaviour
{
    public void Awake()
    {
        StartCoroutine(LifeTime());
    }

    public IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(1f);
    }
}
