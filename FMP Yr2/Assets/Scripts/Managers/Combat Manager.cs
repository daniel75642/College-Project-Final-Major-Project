using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro.Examples;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [SerializeField] List<Transform> forestPlayerPos, wastelandPlayerPos, toxicPlayerPos;
    [SerializeField] List<Transform> forestEnemyPos, wastelandEnemyPos, toxicEnemyPos;
    [SerializeField] List<Transform> forestPlayerPosOrig, forestEnemyPosOrig,
    wastelandPlayerPosOrig, wastelandEnemyPosOrig,
    toxicPlayerPosOrig, toxicEnemyPosOrig;
    [SerializeField] List<GameObject> players;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<GameObject> bosses;
    public List<GameObject> placedEnemies;
    public List<GameObject> placedPlayers;
    public List<GameObject> placedCharacters;
    [SerializeField] List<Vector3> pTransforms;
    [SerializeField] public List<GameObject> playerOrder;
    [SerializeField] List<int> order;

    int speed;

    public bool inCombat, turnOver, wasInCombat, forest, wasteland, toxic;

    public int playersLeft, enemiesLeft;

    public Canvas[] combatCanvas;
    public GameObject[] objs;

    public int objNum;

    public Canvas rewardScreen, explorationCanvas, playerStatsInCombat;

    public PlayerStats ps;
    public EnemyStats es;
    public CameraManger camManger;
    public PlayerManager pm;
    public DataPersistenceManager dpm;
    public CameraController cc;

    public GameObject tutorialAttackDisplayChance;

    public bool isBossCamp;

    public int enemyLevelUp;

    public Slider hackBar;

    public void Start()
    {
        for (int i = 0; i < combatCanvas.Length; i++)
        {
            combatCanvas[i].enabled = false;
        }
        rewardScreen.enabled = false;
    }

    public void Update()
    {
        if(inCombat == false && wasInCombat == true)
        {
            RewardScreen();
            wasInCombat = false;
        }
    }

    public void ForestArenaSetUp()
    {
        forest = true;
        dpm.SaveGame();
        explorationCanvas.enabled = false;
        wasInCombat = true;
        if (pTransforms != null)
        {
            pTransforms.Clear();
        }

        if (placedEnemies != null)
        {
            placedEnemies.Clear();
        }

        inCombat = true;
        for (int i = 0; i < players.Count; i++)
        {
            if(players[i] != null)
            {
                int x = UnityEngine.Random.Range(0, forestPlayerPos.Count);
                pTransforms.Add(players[i].transform.position);
                players[i].transform.position = forestPlayerPos[x].position - new Vector3(0, 0.2f, 0);
                players[i].transform.rotation = Quaternion.Euler(0, -90, 0);
                placedPlayers.Add(players[i]);
                forestPlayerPos.Remove(forestPlayerPos[x]);
            }

            int y = UnityEngine.Random.Range(0, forestEnemyPos.Count);
            GameObject temp = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)],
                new Vector3(forestEnemyPos[y].position.x, forestEnemyPos[y].position.y - 0.2f, forestEnemyPos[y].position.z),
                Quaternion.Euler(0, 90, 0));
            placedEnemies.Add(temp);
            forestEnemyPos.Remove(forestEnemyPos[y]);
        }

        if(isBossCamp == true)
        {
            int y = UnityEngine.Random.Range(0, forestEnemyPos.Count);
            GameObject temp = Instantiate(bosses[UnityEngine.Random.Range(0, bosses.Count)],
                new Vector3(forestEnemyPos[y].position.x, forestEnemyPos[y].position.y - 0.2f, forestEnemyPos[y].position.z),
                Quaternion.Euler(0, 90, 0));
            placedEnemies.Add(temp);
            forestEnemyPos.Remove(forestEnemyPos[y]);
        }

        for (int i = 0; i < placedPlayers.Count;i++)
        {
            placedCharacters.Add(placedPlayers[i]);
        }
        for (int i = 0; i < placedEnemies.Count; i++)
        {
            placedCharacters.Add(placedEnemies[i]);
        }

        playerStatsInCombat.enabled = true;

        StartCoroutine(CombatOrder());
    }

    public void WastelandArenaSetUp()
    {
        wasteland = true;
        dpm.SaveGame();
        explorationCanvas.enabled = false;
        wasInCombat = true;
        if (pTransforms != null)
        {
            pTransforms.Clear();
        }

        if (placedEnemies != null)
        {
            placedEnemies.Clear();
        }

        inCombat = true;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null)
            {
                int x = UnityEngine.Random.Range(0, wastelandPlayerPos.Count);
                pTransforms.Add(players[i].transform.position);
                players[i].transform.position = wastelandPlayerPos[x].position - new Vector3(0, 0.2f, 0);
                players[i].transform.rotation = Quaternion.Euler(0, -90, 0);
                placedPlayers.Add(players[i]);
                wastelandPlayerPos.Remove(wastelandPlayerPos[x]);
            }

            int y = UnityEngine.Random.Range(0, wastelandEnemyPos.Count);
            GameObject temp = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)],
                new Vector3(wastelandEnemyPos[y].position.x, wastelandEnemyPos[y].position.y - 0.2f, wastelandEnemyPos[y].position.z),
                Quaternion.Euler(0, 90, 0));
            placedEnemies.Add(temp);
            wastelandEnemyPos.Remove(wastelandEnemyPos[y]);
        }

        for (int i = 0; i < placedPlayers.Count; i++)
        {
            placedCharacters.Add(placedPlayers[i]);
        }
        for (int i = 0; i < placedEnemies.Count; i++)
        {
            placedCharacters.Add(placedEnemies[i]);
        }

        playerStatsInCombat.enabled = true;

        StartCoroutine(CombatOrder());
    }

    public void ToxicArenaSetUp()
    {
        toxic = true;
        dpm.SaveGame();
        explorationCanvas.enabled = false;
        wasInCombat = true;
        if (pTransforms != null)
        {
            pTransforms.Clear();
        }

        if (placedEnemies != null)
        {
            placedEnemies.Clear();
        }

        inCombat = true;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null)
            {
                int x = UnityEngine.Random.Range(0, toxicPlayerPos.Count);
                pTransforms.Add(players[i].transform.position);
                players[i].transform.position = toxicPlayerPos[x].position - new Vector3(0, 0.2f, 0);
                players[i].transform.rotation = Quaternion.Euler(0, -90, 0);
                placedPlayers.Add(players[i]);
                toxicPlayerPos.Remove(toxicPlayerPos[x]);
            }

            int y = UnityEngine.Random.Range(0, toxicEnemyPos.Count);
            GameObject temp = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)],
                new Vector3(toxicEnemyPos[y].position.x, toxicEnemyPos[y].position.y - 0.2f, toxicEnemyPos[y].position.z),
                Quaternion.Euler(0, 90, 0));
            placedEnemies.Add(temp);
            toxicEnemyPos.Remove(toxicEnemyPos[y]);
        }

        for (int i = 0; i < placedPlayers.Count; i++)
        {
            placedCharacters.Add(placedPlayers[i]);
        }
        for (int i = 0; i < placedEnemies.Count; i++)
        {
            placedCharacters.Add(placedEnemies[i]);
        }

        playerStatsInCombat.enabled = true;

        StartCoroutine(CombatOrder());
    }


    public IEnumerator CombatOrder()
    {

        for (int i = 0; i < players.Count; i++)
        {
            ps = players[i].GetComponent<PlayerStats>();
            speed = ps.playerAttackSpeed;

            order.Add(speed);
        }

        for (int i = 0; i < placedEnemies.Count; i++)
        {
            es = placedEnemies[i].GetComponent<EnemyStats>();
            speed = es.enemyAttackSpeed;

            order.Add(speed);
        }

        order.Sort();

        for (int i = order.Count - 1; i >= 0; i--)
        {
            for(int j = 0; j < order.Count; j++) 
            {
                if (placedCharacters[j].gameObject.CompareTag("Player") && placedCharacters[j].GetComponent<PlayerCombat>().isInOrder == false)
                {
                    ps = placedCharacters[j].GetComponent<PlayerStats>();
                    if (ps.playerAttackSpeed == order[i])
                    {
                        PlayerCombat pc = placedCharacters[j].GetComponent<PlayerCombat>();
                        pc.isInOrder = true;
                        playerOrder.Add(placedCharacters[j]);
                        break;
                    }
                }

                else if (placedCharacters[j].gameObject.CompareTag("Enemy") && placedCharacters[j].GetComponent<EnemyAttack>().isInOrder == false)
                {
                    es = placedCharacters[j].GetComponent<EnemyStats>();
                    if (es.enemyAttackSpeed == order[i])
                    {
                        EnemyAttack ea = placedCharacters[j].GetComponent<EnemyAttack>();
                        ea.isInOrder = true;
                        playerOrder.Add(placedCharacters[j]);
                        break;
                    }
                }
            }
        }

        for (int i = 0; i < players.Count; i++)
        {
            enemyLevelUp += players[i].GetComponent<PlayerLevelling>().level;
        }

        enemyLevelUp = enemyLevelUp / 4;


        for (int i = 0; i < enemies.Count; i++)
        {
            for (int j = 1; j < enemyLevelUp; j++)
            {
                enemies[i].GetComponent<EnemyLevelling>().LevelUp();
            }
        }

        enemiesLeft = 0;
        playersLeft = 0;

        for (int j = 0; j < playerOrder.Count; j++)
        {
            if (playerOrder[j].gameObject.CompareTag("Enemy"))
            {
                enemiesLeft += 1;
            }
            if (playerOrder[j].gameObject.CompareTag("Player"))
            {
                playersLeft += 1;
            }
        }

        for (int i = 0; i < playerOrder.Count; i++)
        {
            yield return new WaitForSeconds(1f);

            if (enemiesLeft <= 0)
            {
                inCombat = false;
                StopAllCoroutines();
                print("Stopped coroutine");
            }

            if (playersLeft <= 0)
            {
                inCombat = false;
                StopAllCoroutines();
                print("Stopped coroutine");
                
            }
            yield return new WaitForSeconds(0.2f);
            print(i);
            if (playerOrder[i].gameObject != null)
            {
                if (playerOrder[i].gameObject.CompareTag("Player"))
                {
                    print("Player Turn Started");
                    PlayerCombat pc = playerOrder[i].GetComponent<PlayerCombat>();
                    pc.isTurn = true;
                    pc.enabled = true;
                    yield return new WaitForSeconds(1);
                    pc.ShowAttackChoices();
                    yield return new WaitForSeconds(0.01f);

                    yield return new WaitUntil(() => turnOver == true);
                    turnOver = false;
                    playerOrder[i].GetComponent<PlayerCombat>().enabled = false;
                }
                else if (playerOrder[i].gameObject.CompareTag("Enemy"))
                {
                    print("Enemy Turn Started");
                    playerOrder[i].GetComponent<EnemyAttack>().enabled = true;
                    EnemyAttack ea = playerOrder[i].GetComponent<EnemyAttack>();
                    ea.isTurn = true;
                    yield return new WaitUntil(() => turnOver == true);
                    turnOver = false;
                    playerOrder[i].GetComponent<EnemyAttack>().enabled = false;
                }
            }

            if (i >= playerOrder.Count - 1)
            {
                i = 0;
            }
            Debug.Log("Missed");
        }
    }

    public void RewardScreen()
    {
        playerStatsInCombat.enabled = false;
        rewardScreen.enabled = true;
    }

    public void CombatOver()
    {
        hackBar.value -= 100;
        enemyLevelUp = 0;
        rewardScreen.enabled = false;
        forestPlayerPos.Clear();
        forestEnemyPos.Clear();
        wastelandPlayerPos.Clear();
        wastelandEnemyPos.Clear();
        toxicPlayerPos.Clear();
        toxicEnemyPos.Clear();
        print("positions cleared");
        camManger.ChangeBack();

        if(isBossCamp == true)
        {
            objs[objNum].SetActive(false);
            objNum += 1;
            objs[objNum].SetActive(true);
            objNum += 1;
        }

        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = pTransforms[i];
            players[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerCombat playerCombat = players[i].GetComponent<PlayerCombat>();
            PlayerStats ps = players[i].GetComponent<PlayerStats>();
            ps.playerExp += 30;
            ps.playerMoney += 25;
            ps.playerHealth += 15;
            if(ps.playerHealth > ps.playerMaxHealth)
            {
                ps.playerHealth = ps.playerMaxHealth;
            }
            playerCombat.isInOrder = false;
            PlayerController pc = players[i].GetComponent<PlayerController>();
            Loadsystem ls = players[i].GetComponent<Loadsystem>();
            pc.CamEnable();
            StartCoroutine(ls.LoadUnload());
        }

        for(int i = 0; i < forestPlayerPosOrig.Count; i++)
        {
            forestPlayerPos.Add(forestPlayerPosOrig[i]);
            forestEnemyPos.Add(forestEnemyPosOrig[i]);
            wastelandPlayerPos.Add(wastelandPlayerPosOrig[i]);
            wastelandEnemyPos.Add(wastelandEnemyPosOrig[i]);
            toxicPlayerPos.Add(toxicPlayerPosOrig[i]);
            toxicEnemyPos.Add(toxicEnemyPosOrig[i]);
        }
        pTransforms.Clear();
        placedCharacters.Clear();
        order.Clear();
        playerOrder.Clear();
        placedPlayers.Clear();
        placedEnemies.Clear();
        explorationCanvas.enabled = true;
        pm.combatSomething = true;
        print("Combat Over");
        StartCoroutine(WaitBeforeTown());
    }

    public void EndTut()
    {
        tutorialAttackDisplayChance.SetActive(false);
    }

    public IEnumerator WaitBeforeTown()
    {
        yield return new WaitForSeconds(1f);
        cc.ShowTown();
    }
}
