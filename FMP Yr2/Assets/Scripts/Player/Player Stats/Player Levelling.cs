using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelling : MonoBehaviour
{
    
    private PlayerStats stats;


    [Header("Health Settings")]
    [SerializeField] public float healthIncrease;


    [Header("Level & Exp Increase Settings")]
    [SerializeField] public int levelIncrease;
    [SerializeField] public float expIncrease;


    [Header("Combat Increase Settings")]
    [SerializeField] public int defenseIncrease;
    [SerializeField] public int intellegenceDefenseIncrease;
    [SerializeField] public int strengthIncrease;
    [SerializeField] public int intellegenceIncrease;
    [SerializeField] public int steadyIncrease;
    [SerializeField] public float attackSpeedIncrease;
    [SerializeField] public float critIncrease;
    [SerializeField] public float attackAccuracyIncrease;


    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }


    void Update()
    {
        if (stats.playerExp >= stats.playerMaxExp && stats.playerLvl < stats.playerMaxLvl)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        //Exp
        stats.playerExp = 0;
        stats.playerLvl += levelIncrease;
        stats.playerMaxExp = (int)Mathf.Round((float)(stats.playerMaxExp * expIncrease));

        //Health
        stats.playerMaxHealth = (int)Mathf.Round((float)(stats.playerMaxHealth * healthIncrease));
        stats.playerHealth = (int)Mathf.Round((float)(stats.playerHealth * healthIncrease));

        //Combat
        stats.playerDefense = (int)Mathf.Round((float)(stats.playerDefense + defenseIncrease));
        stats.playerStrength = (int)Mathf.Round((float)(stats.playerStrength + strengthIncrease));
        stats.playerIntellegence = (int)Mathf.Round((float)(stats.playerIntellegence + intellegenceIncrease));
        stats.playerSteady = (int)Mathf.Round((float)(stats.playerSteady + steadyIncrease));
        stats.playerAttackSpeed = (int)Mathf.Round((float)(stats.playerAttackSpeed * attackSpeedIncrease));
        stats.playerCrit = (int)Mathf.Round((float)(stats.playerCrit * critIncrease));
        stats.playerAttackAccuracy = (int)Mathf.Round((float)(stats.playerAttackAccuracy * attackAccuracyIncrease));
    }
}
