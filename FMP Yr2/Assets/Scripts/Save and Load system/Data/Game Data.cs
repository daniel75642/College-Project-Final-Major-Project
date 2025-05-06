using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //Map Stuff
    public bool mapMade;
    public string seedNumber;

    //Player Manager
    public int playerTurn;

    //Player Stats
    public SerializableDictionary<int, GameObject> players;

    public SerializableDictionary<int, int> playerHealth;
    public SerializableDictionary<int, int> playerMaxHealth;
    public SerializableDictionary<int, int> playerMinHealth;

    public SerializableDictionary<int, int> playerExp;
    public SerializableDictionary<int, int> playerMaxExp;
    public SerializableDictionary<int, int> playerLvl;
    public SerializableDictionary<int, int> playerMaxLvl;

    public SerializableDictionary<int, int> playerDefense;
    public SerializableDictionary<int, int> playerIntellengenceDefence;
    public SerializableDictionary<int, int> playerStrength;
    public SerializableDictionary<int, int> playerIntellegence;
    public SerializableDictionary<int, int> playerSteady;
    public SerializableDictionary<int, int> playerAttackSpeed;
    public SerializableDictionary<int, int> playerCrit;
    public SerializableDictionary<int, int> playerAttackAccuracy;

    public SerializableDictionary<int, int> playerLuck;
    public SerializableDictionary<int, int> playerSpeed;

    public SerializableDictionary<int, int> playerMoney;

    public GameData()
    {
        //Map Stuff
        mapMade = false;
        seedNumber = "";

        //Player Manager
        playerTurn = 0;

        //Player Stats
        playerHealth = new SerializableDictionary<int, int>();
        playerMaxHealth = new SerializableDictionary<int, int>();
        playerMinHealth = new SerializableDictionary<int, int>();

        playerExp = new SerializableDictionary<int, int>();
        playerMaxExp = new SerializableDictionary<int, int>();
        playerLvl = new SerializableDictionary<int, int>();
        playerMaxLvl = new SerializableDictionary<int, int>();

        playerDefense = new SerializableDictionary<int, int>();
        playerIntellengenceDefence = new SerializableDictionary<int, int>();
        playerStrength = new SerializableDictionary<int, int>();
        playerIntellegence = new SerializableDictionary<int, int>();
        playerSteady = new SerializableDictionary<int, int>();
        playerAttackSpeed = new SerializableDictionary<int, int>();
        playerCrit = new SerializableDictionary<int, int>();
        playerAttackAccuracy = new SerializableDictionary<int, int>();

        playerLuck = new SerializableDictionary<int, int>();
        playerSpeed = new SerializableDictionary<int, int>();

        playerMoney = new SerializableDictionary<int, int>();
    }
}
