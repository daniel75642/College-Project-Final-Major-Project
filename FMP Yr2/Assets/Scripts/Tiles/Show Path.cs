using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPath : MonoBehaviour
{
    public void Awake()
    {
        StartCoroutine(LifeTime());
    }

    public IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
