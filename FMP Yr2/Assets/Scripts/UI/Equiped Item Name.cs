using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipedItemName : MonoBehaviour
{
    public GameObject itemIconHolder;

    public WeaponAndArmourShopStuff weaponAndArmourShopStuff;

    public TextMeshProUGUI itemName;

    void Update()
    {
        if (itemIconHolder.GetComponentInChildren<WeaponAndArmourShopStuff>() != null)
        {
            weaponAndArmourShopStuff = itemIconHolder.GetComponentInChildren<WeaponAndArmourShopStuff>();
            itemName.text = weaponAndArmourShopStuff.weaponArmourName;
        }
    }
}
