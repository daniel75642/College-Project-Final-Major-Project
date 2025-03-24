using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class SixDice : MonoBehaviour
{
    public DiceManager diceManager;

    Rigidbody diceRb;

    KeyCode diceRoll = KeyCode.Q;

    int upForce, spinUp, rightLeft, forwardBackward, spinRight;

    public bool rolled, checkNumber;
    
    public float lerpSpeed, rollNumber;

    public LayerMask floor;

    [SerializeField] GameObject diceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        diceRb = gameObject.GetComponent<Rigidbody>();

        rolled = false;
        checkNumber = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (diceRb.velocity == Vector3.zero && rolled == true && checkNumber == false)
        {
            DiceValue();
            if (Input.GetKeyDown(diceRoll) && rolled == false)
            {
                StartCoroutine(ResetDice());
            }
        }

        if (Input.GetKeyDown(diceRoll) && diceRb.velocity == Vector3.zero && rolled == false)
        {
            StartCoroutine(Roll());
            return;
        }


    }

    private IEnumerator Roll()
    {
        checkNumber = false;
        upForce = Random.Range(6, 8);
        rightLeft = Random.Range(-10, 10);
        forwardBackward = Random.Range(-10, 10);
        spinRight = Random.Range(5, 10);
        spinUp = Random.Range(5, 10);

        diceRb.AddForce(Vector3.up * 50f * upForce);
        diceRb.AddForce(Vector3.right * 10f * rightLeft);
        diceRb.AddForce(Vector3.forward * 10f * forwardBackward);
        diceRb.AddTorque(Vector3.up * 90f * spinRight);
        diceRb.AddTorque(Vector3.right * 90f * spinUp);
        yield return new WaitForSeconds(0.5f);
        rolled = true;

    }

    int DiceValue()
    {
        checkNumber = true;
        Vector3[] dir =
        {
            -transform.forward,  //1
            -transform.up,       //2
            -transform.right,     //3
            transform.right,    //4
            transform.up,        //5
            transform.forward    //6
        };

        for (var i = 0; i < dir.Length; i++)
        {
            if (!Physics.Raycast(transform.position, dir[i], 1f, floor)) continue;

            switch (i)
            {
                case 0:
                    rollNumber = 1;break;

                case 1:
                    rollNumber = 2; break;

                case 2:
                    rollNumber = 3; break;

                case 3:
                    rollNumber = 4; break;

                case 4:
                    rollNumber = 5; break;

                case 5:
                    rollNumber = 6; break;

                default:
                    break;
            }
            diceManager.WhatNum();
            return i + 1;
        }
        return 0;

        
        
    }
   
    
    private IEnumerator ResetDice()
    {
        diceRb.transform.position = diceSpawn.transform.position;
        diceRb.transform.rotation = Quaternion.Euler(-90, 0, 0);
        yield return new WaitForSeconds(3);
    }
}
