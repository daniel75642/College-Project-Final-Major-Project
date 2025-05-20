using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats stats;
    public WeaponStats weaponStats;
    public EnemyHealth enemyHealth;
    public AttackChanceDisplay attackChanceDisplay;
    public CombatManager cm;

    public GameObject attackChoice, chooseEnemy, tutorialAttackDisplayChance, attackDisplayChance;

    public bool isTurn, attackChosen, choosingAttack, isInOrder, firstCombat;

    public Transform mouse3D;

    public LayerMask enemyMask;

    public int damage;
    public int intDamage;
    public int steadyDamage;

    public Canvas combatCanvas;
    public void Start()
    {
        stats = GetComponent<PlayerStats>();
        attackChosen = false;
    }

    public void Update()
    {
        if (isTurn == true && attackChosen == false && choosingAttack == false)
        {
            Debug.Log("Choosing Attack");
            attackChosen = false;
            choosingAttack = true;
        }

        if (Input.GetMouseButtonDown(0) && isTurn == true && attackChosen == true && choosingAttack == false)
        {
            if (Physics.Raycast(mouse3D.position, new Vector3(0, -5, 0), 5f, enemyMask))
            {
                attackChosen = false;
                Debug.Log("Enemy Chosen");
                ChooseEnemy();
            }
        }

        Debug.DrawRay(mouse3D.position, new Vector3(0, -5, 0), Color.green);
    }

    public void ChooseEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(mouse3D.position, Vector3.down, out hit, 5f, enemyMask))
        {
            enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth.Health -= (damage + intDamage + steadyDamage);
            Debug.Log("Enemy Hit");
            isTurn = false;
            cm.turnOver = true;
            chooseEnemy.SetActive(false);
        }
    }

    public void Attack1() 
    {
        attackChoice.SetActive(false);
        damage = stats.playerStrength + weaponStats.physicalDamage;
        intDamage = stats.playerIntellegence + weaponStats.intellengenceDamage;
        steadyDamage = stats.playerSteady + weaponStats.physicalDamage;
        StartCoroutine(attackChanceDisplay.Attack());
        attackDisplayChance.SetActive(true);
        if (firstCombat == true) { tutorialAttackDisplayChance.SetActive(true);}
        StartCoroutine(Stop());
        damage = damage * (attackChanceDisplay.successs / 5) - enemyHealth.physicalDefense;
        intDamage = intDamage * (attackChanceDisplay.successs / 5) - enemyHealth.intDefense;
        steadyDamage = steadyDamage * (attackChanceDisplay.successs / 5) - enemyHealth.steadyDefense;
        Debug.Log("Attack 1 Chosen");
    }
    public void Attack2()
    {
        attackChoice.SetActive(false);
        damage = stats.playerStrength + weaponStats.physicalDamage;
        intDamage = stats.playerIntellegence + weaponStats.intellengenceDamage;
        steadyDamage = stats.playerSteady + weaponStats.physicalDamage;
        StartCoroutine(attackChanceDisplay.Attack());
        attackDisplayChance.SetActive(true);
        if (firstCombat == true) { tutorialAttackDisplayChance.SetActive(true); }
        StartCoroutine(Stop());
        damage = damage * (attackChanceDisplay.successs / 5) - enemyHealth.physicalDefense;
        intDamage = intDamage * (attackChanceDisplay.successs / 5) - enemyHealth.intDefense;
        steadyDamage = steadyDamage * (attackChanceDisplay.successs / 5) - enemyHealth.steadyDefense;
        Debug.Log("Attack 2 Chosen");
    }
    public void Attack3()
    {
        attackChoice.SetActive(false);
        damage = stats.playerStrength + weaponStats.physicalDamage;
        intDamage = stats.playerIntellegence + weaponStats.intellengenceDamage;
        steadyDamage = stats.playerSteady + weaponStats.physicalDamage;
        StartCoroutine(attackChanceDisplay.Attack());
        attackDisplayChance.SetActive(true);
        if (firstCombat == true) { tutorialAttackDisplayChance.SetActive(true); }
        StartCoroutine(Stop());
        damage = damage * (attackChanceDisplay.successs / 5) - enemyHealth.physicalDefense;
        intDamage = intDamage * (attackChanceDisplay.successs / 5) - enemyHealth.intDefense;
        steadyDamage = steadyDamage * (attackChanceDisplay.successs / 5) - enemyHealth.steadyDefense;
        Debug.Log("Attack 3 Chosen");
    }

    public void ShowAttackChoices()
    {
        combatCanvas.enabled = true;
        attackChoice.SetActive(true);
    }

    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(3.5f);
        choosingAttack = false; attackChosen = true;
        attackDisplayChance.SetActive(false);
        chooseEnemy.SetActive(true);
        if (firstCombat == true) { tutorialAttackDisplayChance.SetActive(false); firstCombat = false; }
    }
}
