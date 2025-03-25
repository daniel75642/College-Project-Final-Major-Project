using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    Vector3 screenPos, worldPos;
    [SerializeField] LayerMask objsToHit;

    void Update()
    {
        screenPos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hit, 100, objsToHit))
        {
            worldPos = hit.point;
        }

        transform.position = worldPos + new Vector3(0, 0.15f, 0);
    }
}
