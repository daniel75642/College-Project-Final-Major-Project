using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerController[] pControllerScripts;

    public int playerTurn;

    public CameraController cc;

    // Start is called before the first frame update
    void Start()
    {
        playerTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn >= 4)
        {
            playerTurn = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && cc.swapping == false)
        {
            StartCoroutine(PlayerSwap());  StartCoroutine(cc.camSwap());
        }
    }
    public IEnumerator PlayerSwap()
    {
        pControllerScripts[0].enabled = false;  pControllerScripts[1].enabled = false;  pControllerScripts[2].enabled = false;  pControllerScripts[3].enabled = false;
        yield return new WaitForSeconds(1);
        pControllerScripts[playerTurn].enabled = true;
        playerTurn += 1;
    }

}
