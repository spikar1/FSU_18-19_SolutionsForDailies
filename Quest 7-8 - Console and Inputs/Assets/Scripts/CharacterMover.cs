using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour {

    public int x, y;

    bool inputUp, inputDown, inputLeft, inputRight;

    private void Update()
    {
        inputUp = Input.GetKeyDown(KeyCode.W);
        inputDown = Input.GetKeyDown(KeyCode.S);
        inputLeft = Input.GetKeyDown(KeyCode.A);
        inputRight = Input.GetKeyDown(KeyCode.D);

        if (inputUp)
            y++;
        if (inputDown)
            y--;
        if (inputLeft)
            x--;
        if (inputRight)
            x++;

        if(x == 2 && y == 4)
        {
            print("You WIN!!!");
        }
    }
}
