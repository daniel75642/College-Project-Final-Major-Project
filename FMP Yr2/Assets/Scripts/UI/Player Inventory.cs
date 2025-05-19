using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> itemsBought, inventorySlots, spareSlots, filledSlots;

    public int itemsChecked;

    public GameObject weaponSlot, helmetSlot, chestplateSlot, bootSlot;

    public void SetInventory()
    {
        if(itemsBought.Count >= 1)
        {
            for(int i = 0; i < itemsBought.Count && i < inventorySlots.Count; i++)
            {
                GameObject temp = Instantiate(itemsBought[i], spareSlots[0].transform);
                spareSlots.Remove(spareSlots[0]);
                filledSlots.Add(inventorySlots[i]);
            }
        }
        itemsBought.Clear();
    }

    public void clickOnItem()
    {

    }
}
