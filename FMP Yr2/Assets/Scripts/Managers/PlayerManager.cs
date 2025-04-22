using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDataPersistence
{
    [Header("Scripts")]
    [SerializeField] PlayerController[] pControllerScripts;
    [SerializeField] PlayerCombat[] pCombatScripts;
    [SerializeField] NearbyTiles[] pNearbyTiles;
    [SerializeField] GameObject[] players;
    List<Transform> pTransforms;
    public CameraController cc;
    public CombatManager combatManager;

    [Header("Player Turn")]
    public int playerTurn;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (combatManager.inCombat == false)
        {
            if (playerTurn >= 4)
            {
                playerTurn = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space) && cc.swapping == false)
            {
                StartCoroutine(PlayerSwap()); StartCoroutine(cc.camSwap());
            }
        }

        if (combatManager.inCombat == true)
        {
            pTransforms.Clear();
            for (int i = 0; i < pControllerScripts.Length; i++)
            {
                cc.enabled = false;
                pControllerScripts[i].enabled = false;
                pNearbyTiles[i].enabled = false;
                pTransforms[i] = players[i].transform;
                pCombatScripts[i].enabled = true;
            }
        }
    }
    public IEnumerator PlayerSwap()
    {
        pControllerScripts[0].enabled = false;  pControllerScripts[1].enabled = false;  pControllerScripts[2].enabled = false;  pControllerScripts[3].enabled = false;
        pNearbyTiles[0].enabled = false; pNearbyTiles[1].enabled = false; pNearbyTiles[2].enabled = false; pNearbyTiles[3].enabled = false;
        yield return new WaitForSeconds(1);
        pControllerScripts[playerTurn].enabled = true;
        pNearbyTiles[playerTurn].enabled = true;
        playerTurn += 1;
    }

    public void LoadData(GameData data)
    {
        this.playerTurn = data.playerTurn;
    }

    public void SaveData(ref GameData data)
    {
        data.playerTurn = this.playerTurn;
    }

}
