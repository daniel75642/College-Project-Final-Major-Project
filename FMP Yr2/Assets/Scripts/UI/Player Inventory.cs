using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> itemsBought, inventorySlots, spareSlots, filledSlots;

    public PlayerStats stats;

    public int itemsChecked;

    public void Update()
    {

    }
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
}
