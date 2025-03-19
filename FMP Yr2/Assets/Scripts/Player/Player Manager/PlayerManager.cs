using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player1, player2, player3, player4;

    public bool p1Turn, p2Turn, p3Turn, p4Turn;

    private PlayerController p1Controller, p2Controller, p3Controller, p4Controller;

    int playerTurn;

    public CinemachineVirtualCamera cinemachine;

    // Start is called before the first frame update
    void Start()
    {
        p1Controller = player1.GetComponent<PlayerController>();
        p2Controller = player2.GetComponent<PlayerController>();
        p3Controller = player3.GetComponent<PlayerController>();
        p4Controller = player4.GetComponent<PlayerController>();
        playerTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (playerTurn)
            {
                case 0:
                    P1Go(); break;
                case 1:
                    P2Go(); break;
                case 2:
                    P3Go(); break;
                case 3:
                    P4Go(); break;
                default:
                    break;

            }
        }
    }
    public void P1Go()
    {
        playerTurn += 1;
        p4Controller.enabled = false;
        p3Controller.enabled = false;
        p2Controller.enabled = false;
        p1Controller.enabled = true;
        cinemachine.Follow = player1.transform;
    }

    public void P2Go()
    {
        playerTurn += 1;
        p4Controller.enabled = false;
        p3Controller.enabled = false;
        p1Controller.enabled = false;
        p2Controller.enabled = true;
        cinemachine.Follow = player2.transform;
    }

    public void P3Go()
    {
        playerTurn += 1;
        p4Controller.enabled = false;
        p2Controller.enabled = false;
        p1Controller.enabled = false;
        p3Controller.enabled = true;
        cinemachine.Follow = player3.transform;
    }

    public void P4Go()
    {
        playerTurn = 0;
        p3Controller.enabled = false;
        p2Controller.enabled = false;
        p1Controller.enabled = false;
        p4Controller.enabled = true;
        cinemachine.Follow = player4.transform;
    }

}
