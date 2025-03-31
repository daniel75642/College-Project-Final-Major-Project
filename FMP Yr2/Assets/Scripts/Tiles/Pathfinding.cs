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
    public bool mouseHex, playerHex, playerDone, mouseDone;
    public GameObject showPath;
    Hex playerAxialHex, mouseAxialHex;
    List<Cube> cubeLine = new List<Cube>();
    List<Hex> hexOffsetLine = new List<Hex>();

    public void Start()
    {
        mouseHex = false;
        playerHex = false;
        playerDone = false;
        mouseDone = false;
        moveDist = 5;
    }
    /*public void FindMovableTiles(Transform obj)
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

        foreach (Hex hexagonal in hexes)
        {
            Debug.Log($"{hexagonal.Q} , {hexagonal.R}");
        }

    }*/

    public void PlayerFindHex(Transform obj)
    {
        RaycastHit hit;
        bool tileHit = Physics.Raycast(obj.position, Vector3.down, out hit, 10);
        gb = hit.transform.gameObject.GetComponent<GrabCoordinates>();
        offsetCoord hex = new offsetCoord(gb.col, gb.row);
        playerAxialHex = HexConverter.CoordToAxial(hex);
        Debug.Log($"{hex.Col},{hex.Row}");
        playerDone = true;
        playerHex = true;
    }
    public void MouseFindHex(Transform obj)
    {
        RaycastHit hit;
        bool tileHit = Physics.Raycast(obj.position, Vector3.down, out hit, 10);
        gb = hit.transform.gameObject.GetComponent<GrabCoordinates>();
        offsetCoord hex2 = new offsetCoord(gb.col, gb.row);
        mouseAxialHex = HexConverter.CoordToAxial(hex2);
        Debug.Log($"{hex2.Col},{hex2.Row}");
        mouseDone = true;
        mouseHex = true;
    }
    public void Update()
    {
        if (playerHex == true)
        {
            HashSet<Hex> reachableHexes = HexReachable(playerAxialHex, moveDist, hex => false);
            foreach (Hex hex in reachableHexes)
            {
                offsetCoord coord = HexConverter.AxialtoCoord(hex);
                Console.WriteLine($"({coord.Col}, {coord.Row})");
                float row = hex.R * 0.865f;
                float col = hex.Q;
                if (hex.R % 2 == 0)
                {
                    col = (float)(hex.Q);
                }
                else
                {
                    col = (float)(hex.Q + 0.5);
                }
                GameObject temp = Instantiate(showPath, new Vector3(col, 0.2f, row), Quaternion.identity);
            }


            /*cubeLine.Clear();
            hexOffsetLine.Clear();
            Cube newMouseHex = HexConverter.AxialToCube(mouseAxialHex);
            Cube newPlayerHex = HexConverter.AxialToCube(playerAxialHex);
            cubeLine = CubeLineDraw(newPlayerHex, newMouseHex);
            for (int i = 0; i < cubeLine.Count; i++)
            {
                    //print(MathF.Ceiling(cubeLine[i].Q) + ", " + MathF.Ceiling(cubeLine[i].R) + ", " + MathF.Ceiling(cubeLine[i].S));
                Hex newHex = HexConverter.CubeToAxial(cubeLine[i]);
                    //print($"{newHex.Q}, {newHex.R}");
                offsetCoord offsetHex = HexConverter.AxialtoCoord(newHex);
                    //print(offsetHex.Col + ", " + offsetHex.Row);
                float row = offsetHex.Row * 0.865f;
                float col = offsetHex.Col;
                if (offsetHex.Row % 2 == 0)
                {
                    col = (float)(offsetHex.Col);
                }
                else
                {
                    col = (float)(offsetHex.Col + 0.5);
                }
                GameObject temp = Instantiate(showPath, new Vector3(col, 0.2f, row), Quaternion.identity);
            }
            playerHex = false;
            mouseHex = false;
            playerDone = false;
            mouseDone = false;*/
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
            int col = hex.Q + (hex.R - (hex.R % 2)) / 2;
            int row = hex.R;
            return new offsetCoord(col, row);
        }

        public static Hex CoordToAxial(offsetCoord hex)
        {
            int q = hex.Col - (hex.Row - (hex.Row % 2)) / 2;
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

                public static Hex Neighbor(Hex hex, int direction)
        {
            int parity = hex.R & 1; // Determine even or odd row
            int[] diff = OddrDirectionDifferences[parity][direction];
            return new Hex(hex.Q + diff[0], hex.R + diff[1]);
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
        return (Math.Abs(vec.Q) + Math.Abs(vec.Q + vec.R) + Math.Abs(vec.R)) / 2;
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

    public static Cube CubeSubtract(Cube a, Cube b)
    {
        return new Cube(a.Q - b.Q, a.R - b.R, a.S - b.S);
    }

    public static int CubeDist(Cube a, Cube b)
    {
        Cube vec = CubeSubtract(a, b);
        return (int)((MathF.Abs(a.Q - b.Q) + MathF.Abs(a.R - b.R) + MathF.Abs(a.S - b.S)) / 2);
    }

    public static float LinePoints(float a, float b, float t)
    {
        return (a + (b - a) * t);
    }

    public static Cube CubeLerp(Cube a, Cube b, float t)
    {
        return new Cube(
            LinePoints(a.Q, b.Q, t),
            LinePoints(a.R, b.R, t),
            LinePoints(a.S, b.S, t)
        );
    }

    public static Cube CubeRound(Cube c)
    {
        float q = MathF.Round(c.Q);
        float r = MathF.Round(c.R);
        float s = MathF.Round(c.S);

        float qDiff = MathF.Abs(q - c.Q);
        float rDiff = MathF.Abs(r - c.R);
        float sDiff = MathF.Abs(s - c.S);

        if(qDiff > rDiff && qDiff > sDiff)
        {
            q = -r - s;
        }
        else if (rDiff > sDiff)
        {
            r = -q - s;
        }
        else
        {
            s = -q - r;
        }

        return new Cube(q, r, s);
    }

    public static List<Cube> CubeLineDraw(Cube a, Cube b)
    {
        float d = CubeDist(a, b);
        List<Cube> results = new List<Cube>();
        for (int i = 0; i <= d; i++)
        {
            results.Add(CubeRound(CubeLerp(a, b, 1.0f / d * i)));
        }
        return results;
    }

    public static HashSet<Hex> HexReachable(Hex start, int movement, Func<Hex, bool> isBlocked)
    {
        HashSet<Hex> visited = new HashSet<Hex>();
        visited.Add(start);

        List<List<Hex>> fringes = new List<List<Hex>>();
        fringes.Add(new List<Hex> { start });

        for (int k = 1; k <= movement; k++)
        {
            fringes.Add(new List<Hex>());

            foreach (Hex hex in fringes[k - 1])
            {
                for (int dir = 0; dir < 6; dir++)
                {
                    Hex neighbor = OffsetGrid.Neighbor(hex, dir);
                    if (!visited.Contains(neighbor) && !isBlocked(neighbor))
                    {
                        visited.Add(neighbor);
                        fringes[k].Add(neighbor);
                    }
                }
            }
        }

        return visited;
    }
}