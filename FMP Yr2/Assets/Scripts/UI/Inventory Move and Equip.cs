using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMoveandEquip : MonoBehaviour
{
    public GameObject selectionOptions, weaponEquipSlot, helmetEquipSlot, chestEquipSlot, bootEquipSlot;
    public WeaponAndArmourShopStuff weaponAndArmourShopStuff;
    public PlayerStats stats;

    public void Start()
    {
        selectionOptions.SetActive(false);
    }
    public void SelectItem()
    {
        if(GetComponentInChildren<WeaponAndArmourShopStuff>() != null)
        {
            selectionOptions.SetActive(true);
        }
    }

    public void Equip()
    {
        weaponAndArmourShopStuff = GetComponentInChildren<WeaponAndArmourShopStuff>();
        if (weaponAndArmourShopStuff.weaponArmourType == "Weapon")
        {
            if(weaponEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>() != null)
            {
                GameObject temp = weaponEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().gameObject;
                temp.transform.SetParent(this.transform);
                temp.transform.localPosition = Vector3.zero;
            }
            GameObject temp2 = weaponAndArmourShopStuff.gameObject;
            temp2.transform.SetParent(weaponEquipSlot.transform);
            temp2.transform.localPosition = Vector3.zero;
        }

        if (weaponAndArmourShopStuff.weaponArmourType == "Helmet")
        {
            if (helmetEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>() != null)
            {
                GameObject temp = helmetEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().gameObject;
                stats.playerDefense = stats.playerDefense - bootEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().defense;
                stats.playerIntellengenceDefence = stats.playerIntellengenceDefence - bootEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().intDefense;
                temp.transform.SetParent(this.transform);
                temp.transform.localPosition = Vector3.zero;
            }
            GameObject temp2 = weaponAndArmourShopStuff.gameObject;
            temp2.transform.SetParent(helmetEquipSlot.transform);
            temp2.transform.localPosition = Vector3.zero;
            stats.playerDefense = stats.playerDefense + weaponAndArmourShopStuff.defense;
            stats.playerIntellengenceDefence = stats.playerIntellengenceDefence + weaponAndArmourShopStuff.intDefense;
        }

        if (weaponAndArmourShopStuff.weaponArmourType == "Chestplate")
        {
            if (chestEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>() != null)
            {
                GameObject temp = chestEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().gameObject;
                stats.playerDefense = stats.playerDefense - bootEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().defense;
                stats.playerIntellengenceDefence = stats.playerIntellengenceDefence - bootEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().intDefense;
                temp.transform.SetParent(this.transform);
                temp.transform.localPosition = Vector3.zero;
            }
            GameObject temp2 = weaponAndArmourShopStuff.gameObject;
            temp2.transform.SetParent(chestEquipSlot.transform);
            temp2.transform.localPosition = Vector3.zero;
            stats.playerDefense = stats.playerDefense + weaponAndArmourShopStuff.defense;
            stats.playerIntellengenceDefence = stats.playerIntellengenceDefence + weaponAndArmourShopStuff.intDefense;
        }

        if (weaponAndArmourShopStuff.weaponArmourType == "Boots")
        {
            if (bootEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>() != null)
            {
                GameObject temp = bootEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().gameObject;
                stats.playerDefense = stats.playerDefense - bootEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().defense;
                stats.playerIntellengenceDefence = stats.playerIntellengenceDefence - bootEquipSlot.GetComponentInChildren<WeaponAndArmourShopStuff>().intDefense;
                temp.transform.SetParent(this.transform);
                temp.transform.localPosition = Vector3.zero;
            }
            GameObject temp2 = weaponAndArmourShopStuff.gameObject;
            temp2.transform.SetParent(bootEquipSlot.transform);
            temp2.transform.localPosition = Vector3.zero;
            stats.playerDefense = stats.playerDefense + weaponAndArmourShopStuff.defense;
            stats.playerIntellengenceDefence = stats.playerIntellengenceDefence + weaponAndArmourShopStuff.intDefense;
        }

        selectionOptions.SetActive(false);
    }

    public void Cancel()
    {
        selectionOptions.SetActive(false);
    }
}
