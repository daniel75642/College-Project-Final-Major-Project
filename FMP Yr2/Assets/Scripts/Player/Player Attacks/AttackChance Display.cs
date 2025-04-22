using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChanceDisplay : MonoBehaviour
{
    public int attempts, successs;

    public float chance;

    public Canvas attackCanvas;

    bool[] attackAmount;

    public GameObject[] attackDisplay;

    public GameObject attackIcon;
    public GameObject failedIcon;

    float dist = 0;

    public IEnumerator Attack(Canvas attackcanvas)
    {
        dist = 0;
        successs = 0;
        attackAmount = new bool[attempts];

        attackDisplay = new GameObject[attempts];
        List<GameObject> list = new(attackDisplay);

        for (int i = 0; i < attackAmount.Length; i++)
        {
            if (UnityEngine.Random.value <= chance)
            {
                attackAmount[i] = true;
            }

            else if (UnityEngine.Random.value >= chance)
            {
                attackAmount[i] = false;
            }

            print(attackAmount[i]);

            if (attackAmount[i] == true)
            {
                list.Add(Instantiate(attackIcon, new Vector3(dist += 10, 0, 0), Quaternion.Euler(-90, 0, 0)) as GameObject);
                attackDisplay[i] = list[i];
                successs += 1;
            }

            else
            {
                list.Add(Instantiate(failedIcon, new Vector3(dist += 10, 0, 0), Quaternion.Euler(-90, 0, 0)) as GameObject);
                attackDisplay[i] = list[i];
            }
            yield return new WaitForSeconds(0.5f);
        }

    }
}
