using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float vel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vel = playerMovement.rb.velocity.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMovement.rb.velocity.y < -7)
        {
            Debug.Log("Death");
        }
    }
}
