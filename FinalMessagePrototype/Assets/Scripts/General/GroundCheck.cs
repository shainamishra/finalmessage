using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float vel = 0;
    public static bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //vel = playerMovement.rb.velocity.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerMovement.rb.velocity.y < -7) || (dogMovement.rb.velocity.y < -7))
        {
            Debug.Log("Death by broken ankles.");
            dead = true;
        }
    }
}
