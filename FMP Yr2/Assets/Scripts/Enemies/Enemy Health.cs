using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int MaxHealth;
    public int MinHealth;
    public int Health;

    // Start is called before the first frame update
    void Awake()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
