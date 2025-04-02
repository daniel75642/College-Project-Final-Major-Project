using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [Header("Basic Weapon Stats")]
    [SerializeField] int physicalDamage;
    [SerializeField] int intellengenceDamage;
    [SerializeField] int attackAccuracy;
    [SerializeField] int skillChance;

    [Header("Weapon Skills")]
    [SerializeField] bool armourBreak;
    [SerializeField] bool intellegenceArmourBreak;
    [SerializeField] bool hacked;
    [SerializeField] bool slowed;
}
