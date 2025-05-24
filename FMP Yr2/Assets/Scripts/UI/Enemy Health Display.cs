using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthDisplay : MonoBehaviour
{
    public EnemyHealth eh;

    public TextMeshProUGUI health;

    public void Start()
    {
        eh = GetComponentInParent<EnemyHealth>();
        health = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void Update()
    {
        health.text = eh.Health.ToString();
    }
}
