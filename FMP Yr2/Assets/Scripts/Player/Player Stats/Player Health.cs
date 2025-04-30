using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerStats stats;

    [Header("Slider")]
    public Slider slider;

    public int health;
    public int maxhealth;
    public int minhealth;

    void Start()
    {
        HealthUpdate();
    }


    void Update()
    {
        
    }

    public void HealthUpdate()
    {
        stats = GetComponent<PlayerStats>();
        health = stats.playerHealth;
        maxhealth = stats.playerMaxHealth;
        minhealth = stats.playerMinHealth;
        health = maxhealth;
    }
}
