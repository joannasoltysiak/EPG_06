using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject destinyPointPrefab;
    public GameObject cratePrefab;
    public Player player;

    public Transform startTransform;

    void Start()
    {
        
    }


    public Cell[,] Generate(string map)
    {

        string[] rawLines = map.Split("\n".ToCharArray());

        int x = 0;
        int z = 0;

        Cell[,] cellMap = new Cell[rawLines.Length+1,rawLines[1].ToCharArray().Length];

        //Debug.Log(cellMap.Length + " " + rawLines.Length + "  " + rawLines[1].ToCharArray().Length + "     " + rawLines[1]);

        foreach (string line in rawLines) {
            
            foreach (char c in line) {
               
                switch (c) {
                    case '.':
                        PlaceTile(floorPrefab, x, -0.1f, z);
                        cellMap[z,x] = new Cell(CellType.Floor);
                        break;
                    case 'w':
                        PlaceTile(wallPrefab, x, 0.5f, z);
                        cellMap[z, x] = new Cell(CellType.Wall);
                        break;
                    case 'p':
                        player.transform.position = new Vector3(startTransform.position.x + x, 0.5f, startTransform.position.z - z);
                        PlaceTile(floorPrefab, x, -0.1f, z);
                        player.playerPosition = new Vector2Int(z, x);
                        cellMap[z, x] = new Cell(CellType.Floor);
                        break;
                    case 'c':
                        PlaceTile(floorPrefab, x, -0.1f, z);
                        cellMap[z, x] = new Cell(CellType.Floor, PlaceCrate(cratePrefab, x, 0.5f, z));
                        break;
                    case 'd':
                        PlaceTile(floorPrefab, x, -0.1f, z);
                        PlaceTile(destinyPointPrefab, x,  0.01f, z);
                        cellMap[z, x] = new Cell(CellType.TargetSpot);
                        Cell.numberOfCrates++;
                        break;

                }
                if (cellMap[z,x]!=null) {
                    Debug.Log("[" + z + " , " + x + "] --->" + cellMap[z, x].type);
                }
                x++;

            }
            x = 0;
            z++;
        }

        return cellMap;
    }
    private void PlaceTile(GameObject prefab, int x, float y, int z)
    {
        Instantiate(prefab, new Vector3(startTransform.position.x + x, y, startTransform.position.z - z), startTransform.rotation);

    }

    private Transform PlaceCrate(GameObject prefab, int x, float y, int z)
    {
        GameObject crate = Instantiate(prefab, new Vector3(startTransform.position.x + x, y, startTransform.position.z - z), startTransform.rotation);
        return crate.transform;
    }
}
