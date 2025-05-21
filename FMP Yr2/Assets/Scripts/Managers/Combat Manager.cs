using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] List<Transform> forestPlayerPos, wastelandPlayerPos, toxicPlayerPos;
    [SerializeField] List<Transform> forestEnemyPos, wastelandEnemyPos, toxicEnemyPos;
    [SerializeField] List<Transform> forestPlayerPosOrig, forestEnemyPosOrig,
    wastelandPlayerPosOrig, wastelandEnemyPosOrig,
    toxicPlayerPosOrig, toxicEnemyPosOrig;
    [SerializeField] List<GameObject> players;
    [SerializeField] List<GameObject> enemies;
    public List<GameObject> placedEnemies;
    public List<GameObject> placedPlayers;
    public List<GameObject> placedCharacters;
    [SerializeField] List<Vector3> pTransforms;
    [SerializeField] public List<GameObject> playerOrder;
    [SerializeField] List<int> order;

    int speed;

    public bool inCombat, turnOver, wasInCombat;

    public int playersLeft, enemiesLeft;

    public Canvas[] combatCanvas;

    public Canvas rewardScreen, explorationCanvas, playerStatsInCombat;

    public PlayerStats ps;
    public EnemyStats es;
    public CameraManger camManger;
    public PlayerManager pm;
    public DataPersistenceManager dpm;

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
        rewardScreen.enabled = false;
        forestPlayerPos.Clear();
        forestEnemyPos.Clear();
        wastelandPlayerPos.Clear();
        wastelandEnemyPos.Clear();
        toxicPlayerPos.Clear();
        toxicEnemyPos.Clear();
        print("positions cleared");
        camManger.ChangeBack();

        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = pTransforms[i];
            players[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerCombat playerCombat = players[i].GetComponent<PlayerCombat>();
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
    }
}
