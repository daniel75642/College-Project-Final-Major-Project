using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadsystem : MonoBehaviour {
    public Collider[] colliderArray;
    [SerializeField] float loadDist;

    bool check;
    bool firstCheckDone = false;
    int arrayLength;
    // Start is called before the first frame update
    void Start() {
        check = true;
         arrayLength = Physics.OverlapSphere(transform.position, loadDist).Length;

        StartCoroutine(LoadUnload());
    }

    void Update() {

    }

    public IEnumerator LoadUnload() {

        while (check == true) {
            if (!firstCheckDone) {
                firstCheckDone = true;
            }
            else if (firstCheckDone) {
                for (int i = 0; i < arrayLength; i++) {
                    colliderArray[i].transform.GetComponentInChildren<MeshRenderer>().enabled = false;
                }
            }

                
            Array.Clear(colliderArray, 0, colliderArray.Length);

            colliderArray = Physics.OverlapSphere(transform.position, loadDist);
            arrayLength = Physics.OverlapSphere(transform.position, loadDist).Length;

            for (int i = 0; i < arrayLength; i++) {
                colliderArray[i] = Physics.OverlapSphere(transform.position, loadDist)[i];
                colliderArray[i].transform.GetComponentInChildren<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(0.5f);
        }

    }
}
