using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SideMenuStats : MonoBehaviour
{
    public PlayerHealth ph;
    public PlayerStats stats;

    public TextMeshProUGUI health, physicalDefense, intDefense;

    public string healthText, physicalDefenseText, intDefenseText;

    public void Update()
    {
        healthText = ph.health.ToString();
        health.text = healthText;

        physicalDefenseText = stats.playerDefense.ToString();
        physicalDefense.text = physicalDefenseText;

        intDefenseText = stats.playerIntellengenceDefence.ToString();
        intDefense.text = intDefenseText;
    }
}
