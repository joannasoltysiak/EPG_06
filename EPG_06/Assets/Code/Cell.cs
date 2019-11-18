using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public CellType type;
    public Transform item = null;
    public static int numberOfCrates = 0;
    public static int numberOfFilled = 0;

    public Cell(CellType type, Transform item) {
        this.type = type;
        this.item = item;
    }
    public Cell(CellType type) {
        this.type = type;
    }

    public void Put(Transform crate)
    {
        item = crate;

        if (type == CellType.TargetSpot)
            numberOfFilled++;
    }

    public void Remove()
    {
        item = null;
        if (type == CellType.TargetSpot)
            numberOfFilled--;
    }
}
public enum CellType
{
    Floor,
    TargetSpot,
    Wall
}
