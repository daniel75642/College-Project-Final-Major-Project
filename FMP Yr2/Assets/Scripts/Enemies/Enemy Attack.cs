using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public CombatManager cm;
    public EnemyStats stats;
    public EnemyAttackDisplayChance acd;

    public int playerChosen;

    public bool isTurn, choiceMade, isAttacking, isInOrder;

    public void Awake()
    {
        cm = FindObjectOfType<CombatManager>();
        acd = FindObjectOfType<EnemyAttackDisplayChance>();
        isAttacking = false;
        isInOrder = false;
    }
    public void Update()
    {
        if(isTurn == true && choiceMade == false)
        {
            ChoosePlayer();
        }

        if(isTurn == true && choiceMade == true && isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(Attack());
        }
    }


    public void ChoosePlayer()
    {
        print("Enemy Target Chosen");
        playerChosen = Random.Range(0, cm.placedPlayers.Count);
        choiceMade = true;
    }

    public IEnumerator Attack()
    {
        print("Enemy Attacking");
        choiceMade = false;
        PlayerHealth ph = cm.placedPlayers[playerChosen].GetComponent<PlayerHealth>();
        stats = GetComponent<EnemyStats>();
        StartCoroutine(acd.Attack());
        yield return new WaitForSeconds(3.5f);
        ph.health -= stats.enemyDamage * acd.successs / 5;
        print("Damage Done");
        isTurn = false;
        isAttacking = false;
        cm.turnOver = true;
        print("Enemy Turn Ended");
    }
}
