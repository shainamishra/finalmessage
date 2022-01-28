using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject playeron;
    public GameObject dogon;
    public GameObject strikepoint;
    public GameObject rope;
    public GameObject ropeint;
    public GameObject square;

    // Start is called before the first frame update
    void Start()
    {
        rope = GameObject.Find("Rope");
        ropeint = GameObject.Find("RopeInteract");
        square = GameObject.Find("Square");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            strikepoint.SetActive(true);
            Act();
        }
        else 
        { 
            strikepoint.SetActive(false); 
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            Talk();
        }
    }

    void Act() 
    {
        //box collider appears
        //if specific object is in box, then result occurs
        //if ()
        //set unnecessary objects to not active to clear area
    }

    void Talk()
    {
        //dialogue box appears
        //click to progress the text

    }

    // Collision stuff
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "RopeInteract")
        {
            //Debug.Log("RopeInteract");
            rope.SetActive(false);
            ropeint.SetActive(false);
            square.SetActive(false);
            
        }
    }
}
