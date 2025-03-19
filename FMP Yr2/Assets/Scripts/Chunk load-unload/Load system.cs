using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadsystem : MonoBehaviour {
    public Collider[] colliderArray;
    [SerializeField] float loadDist;

    [SerializeField] LayerMask mapLayer;

    bool firstCheckDone = false;
    int arrayLength;
    // Start is called before the first frame update
    void Start() 
    {
         arrayLength = Physics.OverlapSphere(transform.position, loadDist, mapLayer).Length;

        StartCoroutine(LoadUnload());
    }

    public IEnumerator LoadUnload() {

        if (!firstCheckDone)
        {
            firstCheckDone = true;
        }
        else if (firstCheckDone)
        {
            for (int i = 0; i < arrayLength; i++)
            {
                colliderArray[i].transform.GetComponent<MeshRenderer>().enabled = false;
            }
        }


        Array.Clear(colliderArray, 0, colliderArray.Length);

        colliderArray = Physics.OverlapSphere(transform.position, loadDist, mapLayer);
        arrayLength = Physics.OverlapSphere(transform.position, loadDist, mapLayer).Length;

        for (int i = 0; i < arrayLength; i++)
        {
            colliderArray[i] = Physics.OverlapSphere(transform.position, loadDist, mapLayer)[i];
            colliderArray[i].transform.GetComponent<MeshRenderer>().enabled = true;
        }
        yield return null;
    }

}
