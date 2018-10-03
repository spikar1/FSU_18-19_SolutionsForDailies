using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaTime : MonoBehaviour {

    public float secondsSinceLastFrame;
    public float timeLastFrame;

    private void Update()
    {
        secondsSinceLastFrame = Time.time - timeLastFrame;

        print($"Last frame took {secondsSinceLastFrame} seconds.");

        timeLastFrame = Time.time;
    }

}
