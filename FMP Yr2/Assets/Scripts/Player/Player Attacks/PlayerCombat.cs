using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats stats;
    public WeaponStats weaponStats;
    public EnemyHealth enemyHealth;
    public AttackChanceDisplay attackChanceDisplay;

    public Canvas combatCanvas;

    public bool isTurn, attackChosen, choosingAttack;

    public Transform mouse3D;

    public LayerMask enemyMask;

    public int damage;
    public int intDamage;
    public int steadyDamage;

    public void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    public void Update()
    {
        if (isTurn == true && attackChosen == false && choosingAttack == false)
        {
            choosingAttack = true;
            combatCanvas.enabled = true;
        }

        if (Input.GetMouseButtonDown(0) && isTurn == true && attackChosen == true)
        {
            ChooseEnemy();
        }
    }

    public void ChooseEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(mouse3D.position, Vector3.down, out hit, 3f, enemyMask))
        {

            enemyHealth = hit.collider.GetComponent<EnemyHealth>();

        }
    }

    public void Attack1() 
    { 
        damage = stats.playerStrength + weaponStats.physicalDamage;
        intDamage = stats.playerIntellegence + weaponStats.intellengenceDamage;
        steadyDamage = stats.playerSteady + weaponStats.physicalDamage;
        StartCoroutine(attackChanceDisplay.Attack(combatCanvas));
        float d = damage * (attackChanceDisplay.successs / 5);
        float id = intDamage * (attackChanceDisplay.successs / 5);
        float sd = steadyDamage * (attackChanceDisplay.successs / 5);
        combatCanvas.enabled = false; choosingAttack = false;
    }
    public void Attack2()
    {
        damage = stats.playerStrength + weaponStats.physicalDamage;
        intDamage = stats.playerIntellegence + weaponStats.intellengenceDamage;
        steadyDamage = stats.playerSteady + weaponStats.physicalDamage;
        StartCoroutine(attackChanceDisplay.Attack(combatCanvas));
        float d = damage * (attackChanceDisplay.successs / 5);
        float id = intDamage * (attackChanceDisplay.successs / 5);
        float sd = steadyDamage * (attackChanceDisplay.successs / 5);
        combatCanvas.enabled = false; choosingAttack = false;
    }
    public void Attack3()
    {
        damage = stats.playerStrength + weaponStats.physicalDamage;
        intDamage = stats.playerIntellegence + weaponStats.intellengenceDamage;
        steadyDamage = stats.playerSteady + weaponStats.physicalDamage;
        StartCoroutine(attackChanceDisplay.Attack(combatCanvas));
        float d = damage * (attackChanceDisplay.successs / 5);
        float id = intDamage * (attackChanceDisplay.successs / 5);
        float sd = steadyDamage * (attackChanceDisplay.successs / 5);
        combatCanvas.enabled = false; choosingAttack = false;
    }
}
