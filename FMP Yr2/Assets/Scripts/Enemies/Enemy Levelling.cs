using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelling : MonoBehaviour
{
    public EnemyStats stats;
    public EnemyHealth health;

    [Header("Health Settings")]
    [SerializeField] public float healthIncrease;

    [Header("Combat Increase Settings")]
    [SerializeField] public int defenseIncrease;
    [SerializeField] public int intellegenceDefenseIncrease;
    [SerializeField] public int steadyDefenseIncrease;
    [SerializeField] public int damageIncrease;

    public void Awake()
    {
        stats = GetComponent<EnemyStats>();
        health = GetComponent<EnemyHealth>();
    }
    public void LevelUp()
    {
        stats.enemyDamage = (int)Mathf.Round((float)(stats.enemyDamage * damageIncrease));
        health.physicalDefense = (int)Mathf.Round((float)((health.physicalDefense * defenseIncrease)));
        health.intDefense = (int)Mathf.Round((float)(health.intDefense * intellegenceDefenseIncrease));
        health.physicalDefense = (int)Mathf.Round((float)(health.steadyDefense * steadyDefenseIncrease));
        health.MaxHealth = (int)Mathf.Round((float)(health.MaxHealth * healthIncrease));
    }
}
