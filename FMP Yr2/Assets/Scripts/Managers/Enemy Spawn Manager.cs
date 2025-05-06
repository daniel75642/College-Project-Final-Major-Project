using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyCamps;

    public int row, col;

    public LayerMask Spawnable;

    public RaycastHit hit;

    public List<GameObject> enemyPlaces;
    public void SpawnNewEnemies()
    {
        for(int i = 0; i < 3;  i++)
        {
            row = Random.Range(-5, 5);
            col = Random.Range(-5, 5);
            GameObject temp = Instantiate(enemyCamps[0], this.transform.position + new Vector3(row, 0.5f, col), Quaternion.identity);
            if (Physics.Raycast(temp.transform.position, Vector3.down, out hit, 3f, Spawnable))
            {
                GameObject temp2 = Instantiate(enemyCamps[Random.Range(1, enemyCamps.Length)], hit.collider.gameObject.transform.position + new Vector3 (0, 0.2f, 0), Quaternion.identity);
                enemyPlaces.Add(temp2);
            }
            else
            {
                i -= 1;
            }


        }
    }

    public void RemoveEnemies()
    {
        for (int i = 0; i < enemyPlaces.Count; i++)
        {
            Destroy(enemyPlaces[i]);
            enemyPlaces.Remove(enemyPlaces[i]);
        }
    }
}
