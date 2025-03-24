using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    [SerializeField]GameObject[] floorTiles;

    List<GameObject> mapEvenRows = new List<GameObject>();
    List<GameObject> mapOddRows = new List<GameObject>();

    [SerializeField] public float height, width;

    [SerializeField] GameObject mapHolderOddRows, mapHolderEvenRows;

    float rowDist, columnDist;

    int r, q;

    private GrabCoordinates gc;
    // Start is called before the first frame update    
    void Awake()
    {
        StartCoroutine(MakeMap());

        AddMapToParent();
    }

    public IEnumerator MakeMap()
    {
        columnDist = -0.865f;
        rowDist = 0;
        for (r = 0; r < height; r++)
        {
            rowDist = 0;
            columnDist += 0.865f;
            for (q = 0; q < width; q++)
            {
                if (r % 2 == 0)
                {
                    if (q <= 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist, 0, columnDist), Quaternion.identity);
                        mapEvenRows.Add(temp);
                        rowDist += 1f;  
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>();  gc.row = r;  gc.col = q;
                    }

                    else if (q >= width - 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist, 0, columnDist), Quaternion.identity);
                        mapEvenRows.Add(temp);
                        rowDist += 1f;
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;

                    }

                    else if (r <= 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist, 0, columnDist), Quaternion.identity);
                        mapEvenRows.Add(temp);
                        rowDist += 1f;
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                    else if (r >= height - 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist, 0, columnDist), Quaternion.identity);
                        mapEvenRows.Add(temp);
                        rowDist += 1f;
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                    else
                    {
                        int floorTile = UnityEngine.Random.Range(1, 19);
                        GameObject temp = Instantiate(floorTiles[floorTile], new Vector3(rowDist, 0, columnDist), Quaternion.identity);
                        mapEvenRows.Add(temp);
                        rowDist += 1f;
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                }

                else
                {
                    if (q <= 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist + 0.5f, 0, columnDist), Quaternion.identity);
                        mapOddRows.Add(temp);
                        rowDist += 1f;
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                    else if (q >= width - 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist + 0.5f, 0, columnDist), Quaternion.identity);
                        mapOddRows.Add(temp);
                        rowDist += 1f;
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                    else if (r <= 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist + 0.5f, 0, columnDist), Quaternion.identity);
                        mapOddRows.Add(temp);
                        rowDist += 1f;
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                    else if (r >= height - 4)
                    {
                        GameObject temp = Instantiate(floorTiles[0], new Vector3(rowDist + 0.5f, 0, columnDist), Quaternion.identity);
                        mapOddRows.Add(temp);
                        rowDist += 1f;
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                    else
                    {
                        int floorTile = UnityEngine.Random.Range(1, 19);
                        GameObject temp = Instantiate(floorTiles[floorTile], new Vector3(rowDist + 0.5f, 0, columnDist), Quaternion.identity);
                        mapOddRows.Add(temp);
                        rowDist += 1f;
                        temp.name = $"{q},{r}";
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                }

            }
        }
        yield return null;
    }

    public void AddMapToParent()
    {
        for (int i = 0; i < mapEvenRows.Count; i++)
        {
            mapEvenRows[i].transform.parent = mapHolderEvenRows.transform;
        }

        for (int i = 0; i < mapOddRows.Count; i++)
        {
            mapOddRows[i].transform.parent = mapHolderOddRows.transform;
        }
    }
}

