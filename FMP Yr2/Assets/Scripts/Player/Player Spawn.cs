using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerWeapon, playerWeaponHolder;

    public void Awake()
    {
        if(playerWeapon != null && playerWeaponHolder != null)
        {
            Instantiate(playerWeapon, playerWeaponHolder.transform).transform.SetParent(playerWeaponHolder.transform);
        }
    }
}
