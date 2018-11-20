using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public int sizeX, sizeZ;

    public Space spacePrefab;

    [HideInInspector]
    public Space[,] spaces;

    public void Generate()
    {
        spaces = new Space[sizeX, sizeZ];
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                CreateCell(x, z);
            }
        }
    }

    private void CreateCell(int x, int z)
    {
        Space newSpace = Instantiate(spacePrefab) as Space;
        spaces[x, z] = newSpace;
        newSpace.name = "Space " + x + ", " + z;
        newSpace.transform.parent = transform;
        newSpace.transform.localPosition = new Vector3(x - sizeX * 0.5f + 0.5f, 0f, z - sizeZ * 0.5f + 0.5f);
    }
}
