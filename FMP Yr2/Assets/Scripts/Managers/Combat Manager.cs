using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] List<Transform> forestPlayerPos;
    [SerializeField] List<GameObject> players;
    [SerializeField] List<Transform> forestEnemyPos;
    [SerializeField] List<Transform> enemies;
    [SerializeField] List<Vector3> pTransforms;
    [SerializeField] List<GameObject> playerOrder;
    [SerializeField] List<int> order;
    int speed;

    public bool inCombat, turnOver;

    public Canvas[] combatCanvas;

    public void Start()
    {
        for (int i = 0; i < combatCanvas.Length; i++)
        {
            combatCanvas[i].enabled = false;
        }
    }

    public void ForestArenaSetUp()
    {
        if (pTransforms != null)
        {
            pTransforms.Clear();
        }

        inCombat = true;
        for (int i = 0; i < players.Count; i++)
        {
            int x = UnityEngine.Random.Range(0, forestPlayerPos.Count);
            pTransforms.Add(players[i].transform.position);
            players[i].transform.position = forestPlayerPos[x].position;
            forestPlayerPos.Remove(forestPlayerPos[x]);

            int y = UnityEngine.Random.Range(0, forestEnemyPos.Count);
            Instantiate(enemies[UnityEngine.Random.Range(0,2)], new Vector3(forestEnemyPos[y].position.x, forestEnemyPos[y].position.y + 0.15f, forestEnemyPos[y].position.z), Quaternion.Euler(0, 90, 0));
            forestEnemyPos.Remove(forestEnemyPos[x]);
        }
        StartCoroutine(CombatOrder());
    }
    public IEnumerator CombatOrder()
    {
        for (int i = 0; i < 4; i++)
        {
            PlayerStats ps = players[i].GetComponent<PlayerStats>();
            speed = ps.playerAttackSpeed;

            order.Add(speed);
        }

        order.Sort();

        for (int i = 0; i < 4;i++)
        {
            PlayerStats ps = players[i].GetComponent<PlayerStats>();
            for(int j = 0; j < 4; j++) 
            {
                if(ps.playerAttackSpeed == order[j])
                {
                    playerOrder.Add(players[i]);
                } 
            }
        }

        for (int i = 0; i < 4; i++)
        {
            PlayerCombat pc = players[i].GetComponent<PlayerCombat>();
            pc.isTurn = true;
            pc.enabled = true;
            yield return new WaitForSeconds(1);
            pc.ShowAttackChoices();
            yield return new WaitForSeconds(0.01f);

            yield return new WaitUntil(() => turnOver == true);
            turnOver = false;
            playerOrder[i].GetComponent<PlayerCombat>().enabled = false;
        }
    }
}
