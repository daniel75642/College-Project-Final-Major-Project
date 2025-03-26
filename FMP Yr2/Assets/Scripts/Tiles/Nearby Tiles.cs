using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static NearbyTiles;

public class NearbyTiles : MonoBehaviour
{
    private GrabCoordinates gb;
    public int moveDist;
    public bool mouseHex, playerHex, done;
    Hex playerAxialHex, mouseAxialHex;

    public void Start()
    {
        mouseHex = false;
        playerHex = false;
        done = false;
    }
    public void FindMovableTiles(Transform obj)
    {

        RaycastHit hit;
        bool tileHit = Physics.Raycast(obj.position, Vector3.down, out hit, 10);
        gb = hit.transform.gameObject.GetComponent<GrabCoordinates>();
        offsetCoord hex = new offsetCoord(gb.col, gb.row);
        for (int i = 0; i <= 5; i++)
        {
            offsetCoord neighbour = OffsetGrid.OddrOffsetNeighbor(hex, i);
        }

        Hex centre = new Hex(gb.col, gb.row);
        List<Hex> hexes = GetHexRange(centre, moveDist);

        /*foreach (Hex hexagonal in hexes)
        {
            Debug.Log($"{hexagonal.Q} , {hexagonal.R}");
        }*/

    }

    public void PlayerFindHex(Transform obj)
    {
        RaycastHit hit;
        bool tileHit = Physics.Raycast(obj.position, Vector3.down, out hit, 10);
        gb = hit.transform.gameObject.GetComponent<GrabCoordinates>();
        playerHex = true;
    }
    public void MouseFindHex(Transform obj)
    {
        RaycastHit hit;
        bool tileHit = Physics.Raycast(obj.position, Vector3.down, out hit, 10);
        gb = hit.transform.gameObject.GetComponent<GrabCoordinates>();
        mouseHex = true;
    }
    public void Update()
    {
        if (mouseHex == true && playerHex == false && done == false)
        {
            offsetCoord hex2 = new offsetCoord(gb.col, gb.row);
            mouseAxialHex = HexConverter.CoordToAxial(hex2);
            Debug.Log($"{mouseAxialHex.Q},{mouseAxialHex.R}");
            done = true;
        }

        if (playerHex == true && mouseHex == false && done == false)
        {
            offsetCoord hex = new offsetCoord(gb.col, gb.row);
            playerAxialHex = HexConverter.CoordToAxial(hex);
            Debug.Log($"{playerAxialHex.Q},{playerAxialHex.R}");
            done = true;
        }

        if (playerHex == true && mouseHex == true)
        {
            Cube newMouseHex = HexConverter.AxialToCube(mouseAxialHex);
            Cube newPlayerHex = HexConverter.AxialToCube(playerAxialHex);
            for (int i = 0; i < AxialDist(playerAxialHex, mouseAxialHex); i++)
            {
                Debug.Log(CubeLerp(newPlayerHex, newMouseHex, i));
            }
            //Debug.Log(AxialDist(playerAxialHex, mouseAxialHex));
            playerHex = false;
            mouseHex = false;
            done = false;
        }
    }

    public void HexesBetween()
    {

    }

    public struct Cube
    {
        public float Q;
        public float R;
        public float S;

        public Cube(float q, float r, float s)
        {
            Q = q;
            R = r;
            S = -q - r;
        }
    }

    public struct Hex
    {
        public int Q;
        public int R;

        public Hex(int q, int r)
        {
            Q = q;
            R = r;
        }
    }

    public struct offsetCoord
    {
        public int Col;
        public int Row;

        public offsetCoord(int col, int row)
        {
            Col = col;
            Row = row;
        }
    }

    public static class HexConverter
    {
        public static offsetCoord AxialtoCoord(Hex hex)
        {
            int col = hex.Q + (hex.R - (hex.R & 1)) / 2;
            int row = hex.R;
            return new offsetCoord(col, row);
        }

        public static Hex CoordToAxial(offsetCoord hex)
        {
            int q = hex.Col - (hex.Row - (hex.Row % 1)) / 2;
            int r = hex.Row;
            //(5, 5)
            // q = 5 - (5 - (5 % 1)) / 2
            // q = 5 - (5 - (0)) / 2
            // q = 5 - (5 - (0) / 2
            // q = 5 - (5 - 0) / 2
            // q = 5 - 2
            // q = 3
            // r = 5
            // (3, 5)
            // For (5, 6) coord
            // (2, 5)
            return new Hex(q, r);
        }

        public static Hex CubeToAxial(Cube cube)
        {
            int q = (int) cube.Q;
            int r = (int) cube.R;
            return new Hex(q, r);
        }

        public static Cube AxialToCube(Hex hex)
        {
            int q = hex.Q;
            int r = hex.R;
            int s = -q - r;
            return new Cube(q, r, s);
        }

    }

    public static class OffsetGrid
    {
        private static readonly int[][][] OddrDirectionDifferences =
        {
        // Even rows (row % 2 == 0)
        new int[][]
        {
            new int[] { +1,  0 }, new int[] { 0, -1 }, new int[] { -1, -1 },
            new int[] { -1,  0 }, new int[] { -1, +1 }, new int[] { 0, +1 }
        },
        // Odd rows (row % 2 == 1)
        new int[][]
        {
            new int[] { +1,  0 }, new int[] { +1, -1 }, new int[] { 0, -1 },
            new int[] { -1,  0 }, new int[] { 0, +1 }, new int[] { +1, +1 }
        }
    };

        public static offsetCoord OddrOffsetNeighbor(offsetCoord hex, int direction)
        {
            int parity = hex.Row & 1; // Determine even or odd row
            int[] diff = OddrDirectionDifferences[parity][direction];
            return new offsetCoord(hex.Col + diff[0], hex.Row + diff[1]);
        }
    }

    public static Hex AxialAdd(Hex a, Hex b)
    {
        return new Hex(a.Q + b.Q, a.R + b.R);
    }

    public static List<Hex> GetHexRange(Hex center, int N)
    {
        List<Hex> results = new List<Hex>();

        for (int q = -N; q <= N; q++)
        {
            for (int r = Math.Max(-N, -q - N); r <= Math.Min(N, -q + N); r++)
            {
                results.Add(AxialAdd(center, new Hex(q, r)));
            }
        }

        return results;
    }

    public static Hex AxialSubtract(Hex a, Hex b)
    {
        return new Hex (a.Q - b.Q, a.R - b.R);
    }

    public static int AxialDist(Hex a, Hex b)
    {
        Hex vec = AxialSubtract(a, b);
        return (((Math.Abs(vec.Q) + Math.Abs(vec.Q + vec.R)) + Math.Abs(vec.R)) / 2);
        //(5, 7)
        //(2, 5)
        //vec = (3, 2)
        //vecQ = 3
        //VecR = 2
        //((3) + (3 + 2)) + (2) / 2
        //(3 + 5) / 2
        //(8) / 2
        //4
    }

    public static float LinePoints(float a, float b, float t)
    {
        return a + (b - a) * t;
    }

    public static Cube CubeLerp(Cube a, Cube b, float t)
    {
        return new Cube(
            LinePoints(a.Q, b.Q, t),
            LinePoints(a.R, b.R, t),
            LinePoints(a.S, b.S, t)
        );
    }
}
