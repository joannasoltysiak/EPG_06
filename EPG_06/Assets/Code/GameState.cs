using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    Vector2Int playerPositon;
    Vector2Int mapSize;
    public Cell[,] mapData;

    public LevelGenerator levelGen;

    public static int moves;
    public static int pushes;
    public static int crates;

    public Text displayNrOfMoves;
    public Text displayNrOfPushes;
    public Text completed;

    void Start()
    {
        moves = 0;
        pushes = 0;
        crates = 0;
        mapData = levelGen.Generate(LevelLayout.map01);

    }

    void Update()
    {
        displayNrOfMoves.text = "Moves: " + moves;
        displayNrOfPushes.text = "Pushes: " + pushes;
        completed.text = "Completed: " + Cell.numberOfFilled + " / " + Cell.numberOfCrates;

        if (Cell.numberOfFilled == Cell.numberOfCrates)
        {
            //end of the game/ next level
        }
    }
}
