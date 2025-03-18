using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class MapBuilder : MonoBehaviour
{
    [SerializeField]GameObject[] floorTiles;

    [SerializeField] float height, width;

    float rowDist, columnDist;

    GameObject map;

    // Start is called before the first frame update    
    void Start()
    {
        map = Instantiate(gameObject, new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
        StartCoroutine(MakeMap());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MakeMap()
    {
        columnDist = 0;
        rowDist = 0;
        for (int x = 0; x < height; x++)
        {
            rowDist = 0;
            columnDist += 0.865f;
            for (int y = 0; y < width; y++)
            {
                if (x % 2 == 0)
                {
                    if (y <= 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                    else if (y >= width - 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                    else if (x <= 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                    else if (x >= height - 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                    else
                    {
                        int floorTile = Random.Range(1, 6);
                        GameObject temp = Instantiate(floorTiles[floorTile], new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                }

                else
                {
                    if (y <= 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                    else if (y >= width - 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                    else if (x <= 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                    else if (x >= height - 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                    else
                    {
                        int floorTile = Random.Range(1, 6);
                        GameObject temp = Instantiate(floorTiles[floorTile], new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                        temp.transform.parent = map.transform;
                    }

                }

            }
        }
        yield return null;
    }
}
