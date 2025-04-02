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

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        stats.playerHealth = stats.playerMaxHealth;
    }


    void Update()
    {
        
    }
}
