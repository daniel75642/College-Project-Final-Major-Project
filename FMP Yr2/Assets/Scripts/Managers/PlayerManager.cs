using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, IDataPersistence
{
    [Header("Scripts")]
    [SerializeField] PlayerController[] pControllerScripts;
    [SerializeField] PlayerCombat[] pCombatScripts;
    [SerializeField] NearbyTiles[] pNearbyTiles;
    [SerializeField] Loadsystem[] lScripts;
    [SerializeField] EnemySpawnManager[] esScripts;
    [SerializeField] GameObject[] players, diceSpawnPos;
    [SerializeField] GameObject[] bannerStats;
    [SerializeField] GameObject[] playersSideProfile;

    public GameObject dice, diceLimiter;

    public GameObject[] objs;

    public Slider hackBar;

    int hacked;

    public CameraController cc;
    public CombatManager combatManager;
    public SixDice sd;

    [Header("Player Turn")]
    public int playerTurn;

    public bool combatSomething, firstTurn;

    public GameObject diceTut, hackBarTut, invAccessTut, endTurnTut;

    // Start is called before the first frame update
    void Start()
    {
        hackBar.value = hacked;
        StartCoroutine(cc.ShowTown());
    }

    // Update is called once per frame
    void Update()
    {
        hackBar.value = hacked;
        if (combatManager.inCombat == false)
        {
            if (playerTurn >= 4)
            {
                playerTurn = 0;
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

    public void Switch()
    {
        if(cc.swapping == false && pNearbyTiles[playerTurn].playerMoving == false)
        {
            StartCoroutine(PlayerSwap()); StartCoroutine(cc.camSwap());
        }
    }
    public IEnumerator PlayerSwap()
    {
        hacked += 20;
        hackBar.value = hacked;

        dice.SetActive(true);
        diceLimiter.SetActive(true);
        diceLimiter.transform.position = diceSpawnPos[playerTurn].transform.position + new Vector3 (0, 4.3f, 0);
        StartCoroutine(sd.ResetDice());

        pControllerScripts[playerTurn].hasHadTurn = false;
        esScripts[0].enabled = false; esScripts[1].enabled = false; esScripts[2].enabled = false; esScripts[3].enabled = false;
        pControllerScripts[0].enabled = false;  pControllerScripts[1].enabled = false;  pControllerScripts[2].enabled = false;  pControllerScripts[3].enabled = false;
        pNearbyTiles[0].enabled = false; pNearbyTiles[1].enabled = false; pNearbyTiles[2].enabled = false; pNearbyTiles[3].enabled = false;
        lScripts[0].enabled = false; lScripts[1].enabled = false; lScripts[2].enabled = false; lScripts[3].enabled = false;
        bannerStats[0].SetActive(false); bannerStats[1].SetActive(false); bannerStats[2].SetActive(false); bannerStats[3].SetActive(false);
        bannerStats[playerTurn].SetActive(true);

        yield return new WaitForSeconds(1f);

        esScripts[playerTurn].enabled = true;
        pControllerScripts[playerTurn].enabled = true;
        pControllerScripts[playerTurn].hasHadTurn = false;
        pNearbyTiles[playerTurn].enabled = true;
        lScripts[playerTurn].enabled = true;
        if(firstTurn == true)
        {
            diceTut.SetActive(true);
            firstTurn = false;
        }

        if(playerTurn == 0)
        {
            playersSideProfile[0].SetActive(false);
            playersSideProfile[1].SetActive(true);
            playersSideProfile[2].SetActive(false);
            playersSideProfile[3].SetActive(true);
            playersSideProfile[4].SetActive(false);
            playersSideProfile[5].SetActive(true);
        }

        else if (playerTurn == 1)
        {
            playersSideProfile[0].SetActive(true);
            playersSideProfile[1].SetActive(false);
            playersSideProfile[2].SetActive(false);
            playersSideProfile[3].SetActive(true);
            playersSideProfile[4].SetActive(false);
            playersSideProfile[5].SetActive(true);
        }

        else if (playerTurn == 2)
        {
            playersSideProfile[0].SetActive(true);
            playersSideProfile[1].SetActive(false);
            playersSideProfile[2].SetActive(true);
            playersSideProfile[3].SetActive(false);
            playersSideProfile[4].SetActive(false);
            playersSideProfile[5].SetActive(true);
        }

        else if (playerTurn == 3)
        {
            playersSideProfile[0].SetActive(true);
            playersSideProfile[1].SetActive(false);
            playersSideProfile[2].SetActive(true);
            playersSideProfile[3].SetActive(false);
            playersSideProfile[4].SetActive(true);
            playersSideProfile[5].SetActive(false);
        }

        StartCoroutine(lScripts[playerTurn].LoadUnload());

        if (esScripts[0].enemyPlaces != null)
        {
            esScripts[playerTurn].RemoveEnemies();
        }
        esScripts[playerTurn].SpawnNewEnemies();

        playerTurn += 1;
    }

    public void MeadowsFirstShop()
    {
        esScripts[playerTurn].enabled = true;
        esScripts[playerTurn].SpawnBossCamp();
        for (int i = 0; i < pControllerScripts.Length; i++)
        {
            pControllerScripts[i].beenInShop = true;
        }
        objs[0].SetActive(false);
        objs[1].SetActive(true);
        StartCoroutine(cc.ShowBossCamp());
        esScripts[playerTurn].enabled = false;
    }

    public void WastelandFirstShop()
    {
        esScripts[playerTurn].enabled = true;
        esScripts[playerTurn].SpawnBossCamp();
        for (int i = 0; i < pControllerScripts.Length; i++)
        {
            pControllerScripts[i].beenInShop = true;
        }
        objs[2].SetActive(false);
        objs[3].SetActive(true);
        StartCoroutine(cc.ShowBossCamp());
        esScripts[playerTurn].enabled = false;
    }

    public void ToxicFirstShop()
    {
        esScripts[playerTurn].enabled = true;
        esScripts[playerTurn].SpawnBossCamp();
        for (int i = 0; i < pControllerScripts.Length; i++)
        {
            pControllerScripts[i].beenInShop = true;
        }
        objs[4].SetActive(false);
        objs[5].SetActive(true);
        StartCoroutine(cc.ShowBossCamp());
        esScripts[playerTurn].enabled = false;
    }

    public void LoadData(GameData data)
    {
        this.playerTurn = data.playerTurn;
        this.hacked = data.hacked;
    }

    public void SaveData(ref GameData data)
    {
        data.playerTurn = this.playerTurn;
        data.hacked = this.hacked;
    }
    public void EndHackBar()
    {
        hackBarTut.SetActive(false);
        invAccessTut.SetActive(true);
    }

    public void EndInvTut()
    {
        invAccessTut.SetActive(false);
        endTurnTut.SetActive(true);
    }

    public void EndTurnTut()
    {
        endTurnTut.SetActive(false);
    }
}
