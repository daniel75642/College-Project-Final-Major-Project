using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int MaxHealth;
    public int MinHealth;
    public int Health;
    public int physicalDefense, intDefense, steadyDefense;

    // Start is called before the first frame update
    void Awake()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= MinHealth)
        {
            CombatManager cm = FindObjectOfType<CombatManager>();
            cm.enemiesLeft -= 1;
            Destroy(this.gameObject);
        }
    }
}
