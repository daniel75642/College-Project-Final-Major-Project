using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] List<Transform> forestPlayerPos;
    [SerializeField] List<Transform> players;

    public bool inCombat;

    public void ForestArenaSetUp()
    {
        for (int i = 0; i < players.Count; i++)
        {
            int x = Random.Range(0, forestPlayerPos.Count);
            players[i].position = forestPlayerPos[x].position;
            forestPlayerPos.Remove(forestPlayerPos[x]);
        }
    }
    public void CombatOrder()
    {

    }
}
