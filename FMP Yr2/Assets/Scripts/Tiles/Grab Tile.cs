using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTile : MonoBehaviour
{
    public bool isMoveable;
    public LayerMask moveable;

    private void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 10, moveable))
        {
            isMoveable = true;
        }
        else
        {
            isMoveable = false;
        }
    }
}
