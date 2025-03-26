using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]Loadsystem loadSystem;
    [SerializeField]NearbyTiles nearbyTiles;

    [SerializeField] Transform mouse;

    [SerializeField] bool findPlayerTile, findMouseTile;

    public void Start()
    {
        findPlayerTile = false;
        findMouseTile = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.005f, 0, 0 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.005f, 0, 0 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 2f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -2f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(loadSystem.LoadUnload());
        }

        if (Input.GetMouseButton(0) && findMouseTile == true)
        {
            nearbyTiles.MouseFindHex(mouse.transform);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            nearbyTiles.PlayerFindHex(this.transform);
        }
    }
}