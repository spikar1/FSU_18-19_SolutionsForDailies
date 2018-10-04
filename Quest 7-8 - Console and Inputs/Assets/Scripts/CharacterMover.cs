using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour {

    //Headers will show up in the inspector and is a nice way to add information to parameters
    [Header("The position of the player")]
    public int x;
    public int y;
    
    bool inputUp, inputDown, inputLeft, inputRight;

    private void Update()
    {
        //Here we assign the returned bool from GetKeyDown to our bool variables.
        inputUp = Input.GetKeyDown(KeyCode.W);
        inputDown = Input.GetKeyDown(KeyCode.S);
        inputLeft = Input.GetKeyDown(KeyCode.A);
        inputRight = Input.GetKeyDown(KeyCode.D);

        //We can simpy pass a bool as condition, as it will always be either true or false
        if (inputUp)
            y++;
        if (inputDown)
            y--;
        if (inputLeft)
            x--;
        if (inputRight)
            x++;

        //By writing && we can check to see if two conditions return true
        if(x == 2 && y == 4)
        {
            print("You WIN!!!");
        }
    }
}
