using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class NearbyTiles : MonoBehaviour
{
    private GrabCoordinates gb;
    public int moveDist;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            bool tileHit = Physics.Raycast(transform.position, Vector3.down, out hit, 10);
            gb = hit.transform.gameObject.GetComponent<GrabCoordinates>();
            offsetCoord hex = new offsetCoord(gb.col, gb.row);
            for (int i = 0; i <= 5; i++)
            {
                offsetCoord neighbour = OffsetGrid.OddrOffsetNeighbor(hex, i);
            }

            Hex centre = new Hex(gb.col, gb.row);
            List<Hex> hexes = GetHexRange(centre, moveDist);

            foreach(Hex hexagonal in hexes)
            {
                Debug.Log(hexagonal.Q + "," + hexagonal.R);
            }
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
            int q = hex.Col - (hex.Row - (hex.Row & 1)) / 2;
            int r = hex.Row;
            return new Hex(q, r);
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
}
