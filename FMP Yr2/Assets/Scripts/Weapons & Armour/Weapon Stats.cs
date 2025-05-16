using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [Header("Basic Weapon Stats")]
    [SerializeField] public int physicalDamage;
    [SerializeField] public int intellengenceDamage;
    [SerializeField] public int attackAccuracy;
    [SerializeField] public int skillChance;

    [Header("Weapon Skills")]
    [SerializeField] public bool armourBreak;
    [SerializeField] public bool intellegenceArmourBreak;
    [SerializeField] public bool hacked;
    [SerializeField] public bool slowed;
}
