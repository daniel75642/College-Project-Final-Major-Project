using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] List<Transform> forestPlayerPos;
    [SerializeField] List<Transform> players;
    [SerializeField] List<Transform> forestEnemyPos;
    [SerializeField] List<Transform> enemies;
    [SerializeField] List<Vector3> pTransforms;

    public bool inCombat;

    public Canvas combatCanvas;

    public void Start()
    {
        combatCanvas.enabled = false;
    }

    public void ForestArenaSetUp()
    {
        if (pTransforms != null)
        {
            pTransforms.Clear();
        }

        inCombat = true;
        combatCanvas.enabled = true;
        for (int i = 0; i < players.Count; i++)
        {
            int x = Random.Range(0, forestPlayerPos.Count);
            pTransforms.Add(players[i].transform.position);
            players[i].position = forestPlayerPos[x].position;
            forestPlayerPos.Remove(forestPlayerPos[x]);

            int y = Random.Range(0, forestEnemyPos.Count);
            Instantiate(enemies[Random.Range(0,2)], new Vector3(forestEnemyPos[y].position.x, forestEnemyPos[y].position.y + 0.15f, forestEnemyPos[y].position.z), Quaternion.Euler(0, 90, 0));
            forestEnemyPos.Remove(forestEnemyPos[x]);
        }
    }
    public void CombatOrder()
    {

    }
}
