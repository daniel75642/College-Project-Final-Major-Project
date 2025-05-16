using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public bool fisrtShopOpen;

    [SerializeField] public GameObject[] Icons;
    [SerializeField] public TextMeshProUGUI[] itemNames, itemPrices;

    [SerializeField] public GameObject[] commonWeaponsArmour, uncommonWeaponsArmour, 
        rareWeaponsArmour, epicWeaponsArmour, legendaryWeaponsArmour, mythicWeaponsArmour;

    public void ShopCreate()
    {
        if (fisrtShopOpen == false)
        {

        }
    }
}
