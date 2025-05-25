using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    Vector3 screenPos, worldPos;

    [SerializeField] LayerMask objsToHit;

    public Camera[] cams;

    public CombatManager CombatManager;

    Ray ray;

    void Update()
    {
        screenPos = Input.mousePosition;

        if (CombatManager.inCombat == true && CombatManager.toxic == true)
        {
            ray = cams[3].ScreenPointToRay(screenPos);
        }

        if (CombatManager.inCombat == true && CombatManager.wasteland == true)
        {
            ray = cams[2].ScreenPointToRay(screenPos);
        }

        if (CombatManager.inCombat == true && CombatManager.forest == true)
        {
            ray = cams[1].ScreenPointToRay(screenPos);
        }

        else
        {
            ray = cams[0].ScreenPointToRay(screenPos);
        }


        if (Physics.Raycast(ray, out RaycastHit hit, 100, objsToHit))
        {
            worldPos = hit.point;
        }

        transform.position = worldPos + new Vector3(0, 0.05f, 0);
    }
}
