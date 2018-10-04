using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover_Bonus : MonoBehaviour {
    [Header("The position of the player")]
    public int x;
    public int y;
    [Header("The goal position")]
    public int goalX = 2;
    public int goalY = 4;
    [Header("The level bounds")]
    public int minX = -4;
    public int maxX = 4;
    public int minY = -4;
    public int maxY = 4;
    [Header("The GameObject to act as visual representations")]
    public GameObject PlayerAvatar;
    public GameObject goalGameObject;
    [Header("Settings")]
    public bool wrapAround = false;

    bool inputUp, inputDown, inputLeft, inputRight;

    

    private void Update()
    {
        GetInputs();
        if (!wrapAround)
            Move();
        else
            MoveWithWrap();
        UpdatePlayerAvatar();
        UpdateGoalGameObject();
    }

    void GetInputs()
    {
        inputUp = Input.GetKeyDown(KeyCode.W);
        inputDown = Input.GetKeyDown(KeyCode.S);
        inputLeft = Input.GetKeyDown(KeyCode.A);
        inputRight = Input.GetKeyDown(KeyCode.D);
    }

    void Move()
    {
        int lastX = x;
        int lastY = y;
        if (inputUp)
            y++;
        if (inputDown)
            y--;
        if (inputLeft)
            x--;
        if (inputRight)
            x++;

        if (IsOutOfBounds())
        {
            
            x = lastX;
            y = lastY;
            
        }

        ValidatePosition();
    }

    void MoveWithWrap()
    {
        if (inputUp)
            y++;
        if (inputDown)
            y--;
        if (inputLeft)
            x--;
        if (inputRight)
            x++;

        //Wrap X
        if (x < minX)
            x = maxX;
        if (x > maxX)
            x = minX;
        //Wrap Y
        if (y < minY)
            y = maxY;
        if (y > maxY)
            y = minY;

        ValidatePosition();
    }

    void UpdatePlayerAvatar()
    {
        //This makes the z value of the Vector3 zero.
        PlayerAvatar.transform.position = new Vector3(x, y);
    }
    void UpdateGoalGameObject()
    {
        goalGameObject.transform.position = new Vector3(goalX, goalY);
    }

    void ValidatePosition()
    {
        if (IsOutOfBounds())
            return;
        if( x == goalX && y == goalY)
        {
            print("You WIN!!");
            return;
        }
    }

    bool IsOutOfBounds()
    {
        if (x < minX || x > maxX || y < minY || y > maxY)
            return true;
        else
            return false;
    }

    //A nice way to visualize stuff before art is implemented.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(new Vector3(minX + maxX, minY + maxY, 0) / 2, new Vector3(maxX - minX + 1, maxY - minY + 1, 0));
    }
}
