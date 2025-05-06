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
    [SerializeField] Loadsystem[] lScripts;
    [SerializeField] EnemySpawnManager[] esScripts;
    [SerializeField] GameObject[] players, diceSpawnPos;

    public GameObject dice, diceLimiter;

    public CameraController cc;
    public CombatManager combatManager;
    public SixDice sd;

    [Header("Player Turn")]
    public int playerTurn;

    public bool combatSomething;

    

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
            if (Input.GetKeyDown(KeyCode.Space) && cc.swapping == false && pNearbyTiles[playerTurn].playerMoving == false)
            {
                StartCoroutine(PlayerSwap()); StartCoroutine(cc.camSwap());
            }
        }

        if (combatManager.inCombat == true && combatSomething == true)
        {
            combatSomething = false;
            for (int i = 0; i < pControllerScripts.Length; i++)
            {
                cc.enabled = false;
                pControllerScripts[i].enabled = false;
                pNearbyTiles[i].enabled = false;
            }
        }
    }
    public IEnumerator PlayerSwap()
    {
        dice.SetActive(true);
        diceLimiter.SetActive(true);
        diceLimiter.transform.position = diceSpawnPos[playerTurn].transform.position + new Vector3 (0, 4.3f, 0);
        StartCoroutine(sd.ResetDice());

        pControllerScripts[playerTurn].hasHadTurn = false;
        esScripts[0].enabled = false; esScripts[1].enabled = false; esScripts[2].enabled = false; esScripts[3].enabled = false;
        pControllerScripts[0].enabled = false;  pControllerScripts[1].enabled = false;  pControllerScripts[2].enabled = false;  pControllerScripts[3].enabled = false;
        pNearbyTiles[0].enabled = false; pNearbyTiles[1].enabled = false; pNearbyTiles[2].enabled = false; pNearbyTiles[3].enabled = false;
        lScripts[0].enabled = false; lScripts[1].enabled = false; lScripts[2].enabled = false; lScripts[3].enabled = false;

        yield return new WaitForSeconds(1);

        esScripts[playerTurn].enabled = true;
        pControllerScripts[playerTurn].enabled = true;
        pControllerScripts[playerTurn].hasHadTurn = false;
        pNearbyTiles[playerTurn].enabled = true;
        lScripts[playerTurn].enabled = true;

        StartCoroutine(lScripts[playerTurn].LoadUnload());

        if (esScripts[0].enemyPlaces != null)
        {
            esScripts[playerTurn].RemoveEnemies();
        }
        esScripts[playerTurn].SpawnNewEnemies();

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
