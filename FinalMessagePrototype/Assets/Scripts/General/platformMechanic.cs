using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMechanic : MonoBehaviour
{
    public Collider2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            //Debug.Log("up down");
            GetComponent<Collider2D>().enabled = false;
        }
        else 
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }
}
