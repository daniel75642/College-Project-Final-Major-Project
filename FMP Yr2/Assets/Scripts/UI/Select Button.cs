using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public GameObject itemDisplay, iconHolder, selectedItem, armourDisplay;

    public WeaponAndArmourShopStuff itemStats;

    public TextMeshProUGUI itemName, physicalDamage, intDamage, steadyDamage, physicalDefense, intDefense;
    public void SelectSomething()
    {
        itemStats = iconHolder.GetComponentInChildren<WeaponAndArmourShopStuff>();
        if(itemStats.weaponArmourType == "Weapon")
        {
            itemDisplay.SetActive(true);
            itemName.text = itemStats.weaponArmourName;
            physicalDamage.text = $"Physical Damage: {itemStats.physicalDamage}";
            intDamage.text = $"Intellegence Damage: {itemStats.intDamage}";
            steadyDamage.text = $"Steady Damage: {itemStats.steadyDamage}";
            selectedItem = iconHolder.transform.GetChild(0).gameObject;
        }

        else
        {
            armourDisplay.SetActive(true);
            itemName.text = itemStats.weaponArmourName;
            physicalDefense.text = $"Physical Defense: {itemStats.defense}";
            intDefense.text = $"Intellegence Defense: {itemStats.intDefense}";
            selectedItem = iconHolder.transform.GetChild(0).gameObject;
        }
    }
}
