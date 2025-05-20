using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SideMenuStats : MonoBehaviour
{
    public PlayerHealth ph;
    public PlayerStats stats;

    public TextMeshProUGUI health, physicalDefense, intDefense, credits;

    public string healthText, physicalDefenseText, intDefenseText, creditsText;

    public void Update()
    {
        healthText = ph.health.ToString();
        health.text = healthText;

        physicalDefenseText = stats.playerDefense.ToString();
        physicalDefense.text = physicalDefenseText;

        intDefenseText = stats.playerIntellengenceDefence.ToString();
        intDefense.text = intDefenseText;

        creditsText = stats.playerMoney.ToString();
        credits.text = creditsText;
    }
}
