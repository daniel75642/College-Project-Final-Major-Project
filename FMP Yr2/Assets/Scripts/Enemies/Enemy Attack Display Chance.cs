using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDisplayChance : MonoBehaviour
{
    public int attempts, successs;

    public float chance;

    public Canvas attackCanvas;

    bool[] attackAmount;

    public List<GameObject> attackDisplay;

    public GameObject attackIcon;
    public GameObject failedIcon;

    float dist, height;

    public IEnumerator Attack()
    {
        dist = attackCanvas.pixelRect.width / 5;
        height = attackCanvas.pixelRect.height / 2;
        successs = 0;
        attackAmount = new bool[attempts];

        for (int i = 0; i < attackAmount.Length; i++)
        {
            if (Random.value <= chance)
            {
                attackAmount[i] = true;
            }

            else if (Random.value >= chance)
            {
                attackAmount[i] = false;
            }

            if (attackAmount[i] == true)
            {
                attackDisplay.Add(Instantiate(attackIcon, new Vector3(dist += attackCanvas.pixelRect.width / 10, height, 0), Quaternion.Euler(0, 0, 0), this.transform));
                successs += 1;
            }

            else
            {
                attackDisplay.Add(Instantiate(failedIcon, new Vector3(dist += attackCanvas.pixelRect.width / 10, height, 0), Quaternion.Euler(0, 0, 0), this.transform));

            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < attackDisplay.Count;)
        {
            Destroy(attackDisplay[i]);
            attackDisplay.Remove(attackDisplay[i]);
        }
    }
}
