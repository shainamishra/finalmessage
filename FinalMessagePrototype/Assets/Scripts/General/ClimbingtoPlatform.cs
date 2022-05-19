using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the script for phasing through platforms when using ladders

// if there's time, change if GetKey() to if Player.isClimbing?

public class ClimbingtoPlatform : MonoBehaviour
{
    public Collider2D platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            // allow player to phase through
            platform.enabled = false;
        }
        else
        {
            // solid again
            platform.enabled = true;
        }
    }
}
