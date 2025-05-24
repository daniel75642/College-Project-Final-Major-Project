using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public bool firstShopOpen;

    [SerializeField] public GameObject[] Icons;
    [SerializeField] public TextMeshProUGUI[] itemNames, itemPrices;

    [SerializeField] public GameObject[] commonWeaponsArmour, uncommonWeaponsArmour, 
        rareWeaponsArmour, epicWeaponsArmour, legendaryWeaponsArmour, mythicWeaponsArmour;

    [SerializeField] public int howManyCommons, howManyUncommons, howManyRares,
        howManyEpics, howManyLegendarys, howManyMythics;

    [SerializeField] public SelectButton[] selectButtons;

    public int iconNum;

    public Canvas shop;

    public WeaponAndArmourShopStuff blah;
    public PlayerManager pm;
    public PlayerStats[] playersStats;
    public PlayerInventory[] inventories;

    public GameObject itemDisplay, armourDisplay, cantBuy;

    public void Start()
    {
        iconNum = 0;
        firstShopOpen = false;
    }

    public void OpenShop()
    {
        shop.enabled = true;
        Time.timeScale = 0f;
        if (firstShopOpen == false)
        {
            for (int i = 0; i < howManyCommons; i++)
            {
                int x = Random.Range(0, commonWeaponsArmour.Length);
                GameObject temp = Instantiate(commonWeaponsArmour[x], Icons[iconNum].transform.position, Quaternion.identity);
                temp.transform.SetParent(shop.transform);
                blah = commonWeaponsArmour[x].GetComponent<WeaponAndArmourShopStuff>();
                itemNames[iconNum].text = blah.weaponArmourName;
                itemPrices[iconNum].text = blah.weaponArmourCost.ToString();
                temp.transform.SetParent(Icons[iconNum].transform);
                iconNum += 1;
            }

            for (int i = 0; i < howManyUncommons; i++)
            {
                int x = Random.Range(0, uncommonWeaponsArmour.Length);
                GameObject temp = Instantiate(uncommonWeaponsArmour[x], Icons[iconNum].transform.position, Quaternion.identity);
                temp.transform.SetParent(shop.transform);
                blah = uncommonWeaponsArmour[x].GetComponent<WeaponAndArmourShopStuff>();
                itemNames[iconNum].text = blah.weaponArmourName;
                itemPrices[iconNum].text = blah.weaponArmourCost.ToString();
                temp.transform.SetParent(Icons[iconNum].transform);
                iconNum += 1;
            }

            for (int i = 0; i < howManyRares; i++)
            {
                int x = Random.Range(0, rareWeaponsArmour.Length);
                GameObject temp = Instantiate(rareWeaponsArmour[x], Icons[iconNum].transform.position, Quaternion.identity);
                temp.transform.SetParent(shop.transform);
                blah = rareWeaponsArmour[x].GetComponent<WeaponAndArmourShopStuff>();
                itemNames[iconNum].text = blah.weaponArmourName;
                itemPrices[iconNum].text = blah.weaponArmourCost.ToString();
                temp.transform.SetParent(Icons[iconNum].transform);
                iconNum += 1;
            }

            for (int i = 0; i < howManyEpics; i++)
            {
                int x = Random.Range(0, epicWeaponsArmour.Length);
                GameObject temp = Instantiate(epicWeaponsArmour[x], Icons[iconNum].transform.position, Quaternion.identity);
                temp.transform.SetParent(shop.transform);
                blah = epicWeaponsArmour[x].GetComponent<WeaponAndArmourShopStuff>();
                itemNames[iconNum].text = blah.weaponArmourName;
                itemPrices[iconNum].text = blah.weaponArmourCost.ToString();
                temp.transform.SetParent(Icons[iconNum].transform);
                iconNum += 1;
            }

            for (int i = 0; i < howManyLegendarys; i++)
            {
                int x = Random.Range(0, legendaryWeaponsArmour.Length);
                GameObject temp = Instantiate(legendaryWeaponsArmour[x], Icons[iconNum].transform.position, Quaternion.identity);
                temp.transform.SetParent(shop.transform);
                blah = legendaryWeaponsArmour[x].GetComponent<WeaponAndArmourShopStuff>();
                itemNames[iconNum].text = blah.weaponArmourName;
                itemPrices[iconNum].text = blah.weaponArmourCost.ToString();
                temp.transform.SetParent(Icons[iconNum].transform);
                iconNum += 1;
            }

            for (int i = 0; i < howManyMythics; i++)
            {
                int x = Random.Range(0, mythicWeaponsArmour.Length);
                GameObject temp = Instantiate(mythicWeaponsArmour[x], Icons[iconNum].transform.position, Quaternion.identity);
                temp.transform.SetParent(shop.transform);
                blah = mythicWeaponsArmour[x].GetComponent<WeaponAndArmourShopStuff>();
                itemNames[iconNum].text = blah.weaponArmourName;
                itemPrices[iconNum].text = blah.weaponArmourCost.ToString();
                temp.transform.SetParent(Icons[iconNum].transform);
                iconNum += 1;
            }

            firstShopOpen = true;
        }
    }

    public void CloseShop()
    {
        Time.timeScale = 1f;
        itemDisplay.SetActive(false);
        shop.enabled = false;
    }
    public void DeselectSomething()
    {
        itemDisplay.SetActive(false);
        for (int i = 0; i < selectButtons.Length; i++)
        {
            selectButtons[i].selectedItem = null;
        }
    }

    public void BuySomething()
    {
        for (int i = 0; i < selectButtons.Length; i++)
        {
            int player = pm.playerTurn;
            bool playerTurnSwapped = false;
            if (player == 0 && playerTurnSwapped == false) { player = 3; playerTurnSwapped = true; }
            if (player == 1 && playerTurnSwapped == false) { player = 0; playerTurnSwapped = true; }
            if (player == 2 && playerTurnSwapped == false) { player = 1; playerTurnSwapped = true; }
            if (player == 3 && playerTurnSwapped == false) { player = 2; playerTurnSwapped = true; }

            if (selectButtons[i].selectedItem != null)
            {
                blah = selectButtons[i].selectedItem.GetComponent<WeaponAndArmourShopStuff>();
                if (playersStats[player].playerMoney >= blah.weaponArmourCost)
                {
                    playersStats[player].playerMoney -= blah.weaponArmourCost;
                    inventories[player].itemsBought.Add(selectButtons[i].selectedItem);
                    //inventories[pm.playerTurn].SetInventory();
                    selectButtons[i].selectedItem = null;
                    selectButtons[i].GetComponent<Button>().enabled = false;
                    selectButtons[i].GetComponent<UnityEngine.UI.Image>().color = Color.red;
                    itemDisplay.SetActive(false);
                    armourDisplay.SetActive(false);
                }

                else
                {
                    cantBuy.SetActive(true);
                }
            }
        }
    }

    public void CloseThis()
    {
        cantBuy.SetActive(false);
    }
}
