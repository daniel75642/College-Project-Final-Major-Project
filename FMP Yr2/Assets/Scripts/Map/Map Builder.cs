using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class MapBuilder : MonoBehaviour
{
    [SerializeField] GameObject walkable, notWalkable, water;

    [SerializeField] float height, width;

    float rowDist, columnDist;

    // Start is called before the first frame update
    void Start()
    {
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
                        GameObject temp = Instantiate(water, new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                    else if (y >= width - 4)
                    {
                        GameObject temp = Instantiate(water, new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                    else if (x <= 4)
                    {
                        GameObject temp = Instantiate(water, new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                    else if (x >= height - 4)
                    {
                        GameObject temp = Instantiate(water, new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                    else
                    {
                        GameObject temp = Instantiate(walkable, new Vector3(rowDist, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                }

                else
                {
                    if (y <= 4)
                    {
                        GameObject temp = Instantiate(water, new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                    else if (y >= width - 4)
                    {
                        GameObject temp = Instantiate(water, new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                    else if (x <= 4)
                    {
                        GameObject temp = Instantiate(water, new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                    else if (x >= height - 4)
                    {
                        GameObject temp = Instantiate(water, new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                    else
                    {
                        GameObject temp = Instantiate(walkable, new Vector3(rowDist + 0.5f, 0, columnDist + 0.865f), Quaternion.identity);
                        rowDist += 1f;
                        temp.name = $"{x},{y}";
                    }

                }

            }
        }
        yield return null;
    }
}
