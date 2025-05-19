using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public Canvas p1Inv, p2Inv, p3Inv, p4Inv;
    public void P1OpenInventory()
    {
        Time.timeScale = 0f;
        p1Inv.enabled = true;
        PlayerInventory pi = p1Inv.GetComponent<PlayerInventory>();
        pi.SetInventory();
    }

    public void P2OpenInventory()
    {
        Time.timeScale = 0f;
        p2Inv.enabled = true;
        PlayerInventory pi = p2Inv.GetComponent<PlayerInventory>();
        pi.SetInventory();
    }

    public void P3OpenInventory()
    {
        Time.timeScale = 0f;
        p3Inv.enabled = true;
        PlayerInventory pi = p3Inv.GetComponent<PlayerInventory>();
        pi.SetInventory();
    }

    public void P4OpenInventory()
    {
        Time.timeScale = 0f;
        p4Inv.enabled = true;
        PlayerInventory pi = p4Inv.GetComponent<PlayerInventory>();
        pi.SetInventory();
    }

    public void CloseInventories()
    {
        Time.timeScale = 1f;
        p1Inv.enabled = false;
        p2Inv.enabled = false;
        p3Inv.enabled = false;
        p4Inv.enabled = false;
    }

}
