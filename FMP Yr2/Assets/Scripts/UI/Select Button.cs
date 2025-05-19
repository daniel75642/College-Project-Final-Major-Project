using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public GameObject itemDisplay, iconHolder, selectedItem;

    public WeaponAndArmourShopStuff itemStats;

    public TextMeshProUGUI itemName, physicalDamage, intDamage, steadyDamage;
    public void SelectSomething()
    {
        itemDisplay.SetActive(true);
        itemStats = iconHolder.GetComponentInChildren<WeaponAndArmourShopStuff>();
        itemName.text = itemStats.weaponArmourName;
        physicalDamage.text = $"Physical Damage: {itemStats.physicalDamage}";
        intDamage.text = $"Intellegence Damage: {itemStats.intDamage}";
        steadyDamage.text = $"Steady Damage: {itemStats.steadyDamage}";
        selectedItem = iconHolder.transform.GetChild(0).gameObject;
    }
}
