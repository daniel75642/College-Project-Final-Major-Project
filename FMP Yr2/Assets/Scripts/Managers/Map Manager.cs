using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour, IDataPersistence
{
    public Loadsystem ls;

    [SerializeField]GameObject[] floorTiles;

    List<GameObject> mapEvenRows = new List<GameObject>();
    List<GameObject> mapOddRows = new List<GameObject>();

    [SerializeField] public int height, width;

    [SerializeField] GameObject mapHolderOddRows, mapHolderEvenRows;

    float rowDist, columnDist;

    int r, q;
    public int seed;
    public string seedNumber;

    private GrabCoordinates gc;

    public bool mapMade;

    public Vector3 startPos;

    // Start is called before the first frame update    
    void Start()
    {
        if(mapMade == false)
        {
            seedNumber = UnityEngine.Random.Range(0,10000000).ToString();
        }
        StartCoroutine(MakeMap());
        AddMapToParent();
    }

    public IEnumerator MakeMap()
    {

        seed = int.Parse(seedNumber);

        UnityEngine.Random.InitState(seed);
        
        mapMade = true;

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
                    if (q == 15 && r == 15)
                    {
                        GameObject temp = Instantiate(floorTiles[1], startPos + new Vector3(rowDist, 0, columnDist), Quaternion.identity);
                        mapEvenRows.Add(temp);
                        rowDist += 1f;
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                    else if (q == 22 && r == 22)
                    {
                        GameObject temp = Instantiate(floorTiles[0], startPos + new Vector3(rowDist, 0, columnDist), Quaternion.identity);
                        mapEvenRows.Add(temp);
                        rowDist += 1f;
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                    else
                    {
                        int floorTile = UnityEngine.Random.Range(2, floorTiles.Length);
                        GameObject temp = Instantiate(floorTiles[floorTile], startPos + new Vector3(rowDist, 0, columnDist), Quaternion.identity);
                        mapEvenRows.Add(temp);
                        rowDist += 1f;
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                }

                else
                {
                    if (q == 15 && r == 15)
                    {
                        GameObject temp = Instantiate(floorTiles[1], startPos + new Vector3(rowDist + 0.5f, 0, columnDist), Quaternion.identity);
                        mapOddRows.Add(temp);
                        rowDist += 1f;
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }


                    else if (q == 22 && r == 22)
                    {
                        GameObject temp = Instantiate(floorTiles[0], startPos + new Vector3(rowDist, 0, columnDist), Quaternion.identity);
                        mapOddRows.Add(temp);
                        rowDist += 1f;
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                    else
                    {
                        int floorTile = UnityEngine.Random.Range(2, floorTiles.Length);
                        GameObject temp = Instantiate(floorTiles[floorTile], startPos + new Vector3(rowDist + 0.5f, 0, columnDist), Quaternion.identity);
                        mapOddRows.Add(temp);
                        rowDist += 1f;
                        gc = temp.GetComponent<GrabCoordinates>(); gc.row = r; gc.col = q;
                    }

                }
            }
        }
        StartCoroutine(ls.LoadUnload());
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

    public void LoadData(GameData data)
    {
        this.mapMade = data.mapMade;
        this.seedNumber = data.seedNumber;
    }

    public void SaveData(ref GameData data)
    {
        data.mapMade = this.mapMade;
        data.seedNumber = this.seed.ToString();
    }
}

