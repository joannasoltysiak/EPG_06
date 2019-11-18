using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    public GameState gameState; 
    public Vector2Int playerPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(0, 1);
        }
    }

    void Move(int x, int z) {
        if (gameState.mapData[playerPosition.x - z, playerPosition.y + x].item != null)
        {
            if(CanPush(playerPosition.x - 2*z, playerPosition.y + 2 * x))
                Push(x, z);
        }
        else if (gameState.mapData[playerPosition.x - z, playerPosition.y + x].type != CellType.Wall)
        {
            transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
            GameState.moves++;
            playerPosition.Set(playerPosition.x - z, playerPosition.y + x);
        }
        //Debug.Log("player position: " + playerPosition + " " + gameState.mapData[playerPosition.x - z, playerPosition.y + x].type);
    }

    void Push(int x, int z) {

        Transform tmp = gameState.mapData[playerPosition.x - z, playerPosition.y + x].item;
  
        tmp.position = new Vector3(tmp.position.x + x, tmp.position.y, tmp.position.z + z);

        gameState.mapData[playerPosition.x - z, playerPosition.y + x].Remove();

        gameState.mapData[playerPosition.x - 2*z, playerPosition.y + 2*x].Put(tmp);

        transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        GameState.pushes++;
        playerPosition.Set(playerPosition.x - z, playerPosition.y + x);
}

      bool CanPush(int posX, int posY)
    {
        if(gameState.mapData[posX, posY].item != null)
        {
            return false;
        }
        if (gameState.mapData[posX, posY].type == CellType.Wall)
        {
            return false;
        }

        return true;
    }  
}
