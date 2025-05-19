using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public GameObject weaponEquipSlot;
    public WeaponAndArmourShopStuff weapon;

    [Header("Basic Weapon Stats")]
    [SerializeField] public int physicalDamage;
    [SerializeField] public int intellengenceDamage;
    [SerializeField] public int steadyDamage;

    public void Update()
    {
        if(weaponEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>() != null)
        {
            weapon = weaponEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>();
            physicalDamage = weapon.physicalDamage;
            intellengenceDamage = weapon.intDamage;
            steadyDamage = weapon.steadyDamage;
        }
    }
}
