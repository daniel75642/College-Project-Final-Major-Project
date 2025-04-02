using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("Health Settings")]
    [SerializeField] public int playerHealth;
    [SerializeField] public int playerMaxHealth;
    [SerializeField] public int playerHealthMin;


    [Header("Lvl & Exp Settings")]
    [SerializeField] public int playerExp;
    [SerializeField] public int playerMaxExp;
    [SerializeField] public int playerLvl;
    [SerializeField] public int playerMaxLvl;


    [Header("Combat Settings")]
    [SerializeField] public int playerDefense;
    [SerializeField] public int playerIntellengenceDefence;
    [SerializeField] public int playerStrength;
    [SerializeField] public int playerIntellegence;
    [SerializeField] public int playerSteady;
    [SerializeField] public int playerAttackSpeed;
    [SerializeField] public int playerCrit;
    [SerializeField] public int playerAttackAccuracy;



    [Header("General Buff Settings")]
    [SerializeField] public int playerLuck;
    [SerializeField] public int playerSpeed;


    [Header("Money")]
    [SerializeField] public int playerMoney;

}
/* Paladin 
 * Health - 30
 * Defense - 4
 * Attack Speed - 40
 * Crit Chance - 10%
 * Strength - 4
 * Intellegence - 0
 * AttackAccuracy - 5%
 * Luck - 3 -  for dig site etc for example here the player would have to roll a 4 or above to succeed
 * Speed - 0
 * Money - 10
 */

/* Mage
 * Health - 24
 * Defense - 2
 * Attack Speed - 70
 * Crit Chance - 15%
 * Strength - 1
 * Intellegence - 5
 * AttackAccuracy - 15%
 * Luck - 4 -  for dig site etc for example here the player would have to roll a 4 or above to succeed
 * Speed - 0
 * Money - 10
 * */

/* Fighter
 * Health - 28
 * Defense - 3
 * Attack Speed - 60
 * Crit Chance - 12%
 * Strength - 3
 * Intellegence - 1
 * AttackAccuracy - 12%
 * Luck - 2 -  for dig site etc for example here the player would have to roll a 4 or above to succeed
 * Speed - 0
 * Money - 10
 * */

/* Rogue
 * Health - 24
 * Defense - 2
 * Attack Speed - 75
 * Crit Chance - 18%
 * Strength - 1
 * Intellegence - 1
 * Steady - 4
 * AttackAccuracy - 25%
 * Luck - 3 -  for dig site etc for example here the player would have to roll a 4 or above to succeed
 * Speed - 0
 * Money - 10
 * */