using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDataPersistence
{
    public int playerNumber;

    [Header("Health Settings")]
    [SerializeField] public int playerHealth;
    [SerializeField] public int playerMaxHealth;
    [SerializeField] public int playerMinHealth;


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


    public void LoadData(GameData data)
    {
        playerHealth = data.playerHealth[playerNumber];
        playerMaxHealth = data.playerMaxHealth[playerNumber];
        playerMinHealth = data.playerMinHealth[playerNumber];

        playerExp = data.playerExp[playerNumber];
        playerMaxExp = data.playerMaxExp[playerNumber];
        playerLvl = data.playerLvl[playerNumber];
        playerMaxLvl = data.playerMaxLvl[playerNumber];

        playerDefense = data.playerDefense[playerNumber];
        playerIntellengenceDefence = data.playerIntellengenceDefence[playerNumber];
        playerStrength = data.playerStrength[playerNumber];
        playerIntellegence = data.playerIntellegence[playerNumber];
        playerSteady = data.playerSteady[playerNumber];
        playerAttackSpeed = data.playerAttackSpeed[playerNumber];
        playerCrit = data.playerCrit[playerNumber];
        playerAttackAccuracy = data.playerAttackAccuracy[playerNumber];

        playerLuck = data.playerLuck[playerNumber];
        playerSpeed = data.playerSpeed[playerNumber];

        playerMoney = data.playerMoney[playerNumber];
    }

    public void SaveData(ref GameData data)
    {
        if (data.playerHealth.ContainsKey(playerNumber))
        {
            data.playerHealth.Clear();
        }
        data.playerHealth.Add(playerNumber, playerHealth);

        if (data.playerMaxHealth.ContainsKey(playerNumber))
        {
            data.playerMaxHealth.Clear();
        }
        data.playerMaxHealth.Add(playerNumber, playerMaxHealth);

        if (data.playerMinHealth.ContainsKey(playerNumber))
        {
            data.playerMinHealth.Clear();
        }
        data.playerMinHealth.Add(playerNumber, playerMinHealth);

        if (data.playerExp.ContainsKey(playerNumber))
        {
            data.playerExp.Clear();
        }
        data.playerExp.Add(playerNumber, playerExp);

        if (data.playerMaxExp.ContainsKey(playerNumber))
        {
            data.playerMaxExp.Clear();
        }
        data.playerMaxExp.Add(playerNumber, playerMaxExp);

        if (data.playerLvl.ContainsKey(playerNumber))
        {
            data.playerLvl.Clear();
        }
        data.playerLvl.Add(playerNumber, playerLvl);

        if (data.playerMaxLvl.ContainsKey(playerNumber))
        {
            data.playerMaxLvl.Clear();
        }
        data.playerMaxLvl.Add(playerNumber, playerMaxLvl);

        if (data.playerDefense.ContainsKey(playerNumber))
        {
            data.playerDefense.Clear();
        }
        data.playerDefense.Add(playerNumber, playerDefense);

        if (data.playerIntellengenceDefence.ContainsKey(playerNumber))
        {
            data.playerIntellengenceDefence.Clear();
        }
        data.playerIntellengenceDefence.Add(playerNumber, playerIntellengenceDefence);

        if (data.playerStrength.ContainsKey(playerNumber))
        {
            data.playerStrength.Clear();
        }
        data.playerStrength.Add(playerNumber, playerStrength);

        if (data.playerIntellegence.ContainsKey(playerNumber))
        {
            data.playerIntellegence.Clear();
        }
        data.playerIntellegence.Add(playerNumber, playerIntellegence);

        if (data.playerSteady.ContainsKey(playerNumber))
        {
            data.playerSteady.Clear();
        }
        data.playerSteady.Add(playerNumber, playerSteady);

        if (data.playerAttackSpeed.ContainsKey(playerNumber))
        {
            data.playerAttackSpeed.Clear();
        }
        data.playerAttackSpeed.Add(playerNumber, playerAttackSpeed);

        if (data.playerCrit.ContainsKey(playerNumber))
        {
            data.playerCrit.Clear();
        }
        data.playerCrit.Add(playerNumber, playerCrit);

        if (data.playerAttackAccuracy.ContainsKey(playerNumber))
        {
            data.playerAttackAccuracy.Clear();
        }
        data.playerAttackAccuracy.Add(playerNumber, playerAttackAccuracy);

        if (data.playerLuck.ContainsKey(playerNumber))
        {
            data.playerLuck.Clear();
        }
        data.playerLuck.Add(playerNumber, playerLuck);

        if (data.playerSpeed.ContainsKey(playerNumber))
        {
            data.playerSpeed.Clear();
        }
        data.playerSpeed.Add(playerNumber, playerSpeed);

        if (data.playerMoney.ContainsKey(playerNumber))
        {
            data.playerMoney.Clear();
        }
        data.playerMoney.Add(playerNumber, playerMoney);
    }
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