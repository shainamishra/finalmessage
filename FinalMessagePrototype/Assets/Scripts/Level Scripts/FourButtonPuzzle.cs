using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourButtonPuzzle : MonoBehaviour
{
    public Collider2D dog;
    public Collider2D player;
    public Collider2D button1;
    public Collider2D button2;
    public Collider2D button3;
    public Collider2D button4;
    public GameObject LLadder;
    public GameObject RLadder;
    public GameObject LDoor;
    public GameObject RDoor;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<Collider2D>();
        button1 = GameObject.Find("Button1").GetComponent<Collider2D>();
        button2 = GameObject.Find("Button2").GetComponent<Collider2D>();
        button3 = GameObject.Find("Button3").GetComponent<Collider2D>();
        button4 = GameObject.Find("Button4").GetComponent<Collider2D>();
        LLadder = GameObject.Find("LeftLadder");
        RLadder = GameObject.Find("RightLadder");
        LDoor = GameObject.Find("LeftDoor");
        RDoor = GameObject.Find("RightDoor");
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is on the button1
        if (button1.IsTouching(player) || button1.IsTouching(dog))
        {
            // then the button is lowered
            Vector3 temp1 = new Vector3(-5.1f, -4.4f, 0.0f);
            button1.transform.position = temp1;
            if (LDoor.transform.position.y > -6.5f)
            { 
                LDoor.transform.position += new Vector3(0.0f, -0.005f, 0.0f); 
            }
        }
        else
        {
            // raise the button
            Vector3 temp1 = new Vector3(-5.1f, -4.2f, 0.0f);
            button1.transform.position = temp1;
            /*if (LDoor.transform.position.y < -2.8f)
            {
                LDoor.transform.position += new Vector3(0.0f, 0.005f, 0.0f);
            }*/
        }

        // if the dog is on the button2
        if (button2.IsTouching(player) || button2.IsTouching(dog))
        {
            // then the button is lowered
            Vector3 temp2 = new Vector3(0.05f, -4.4f, 0.0f);
            button2.transform.position = temp2;
            if (LLadder.transform.position.y > -1.5f)
            {
                LLadder.transform.position += new Vector3(0.0f, -0.005f, 0.0f);
            }
        }
        else
        {
            // raise the button
            Vector3 temp2 = new Vector3(0.05f, -4.2f, 0.0f);
            button2.transform.position = temp2;
            /*if (LLadder.transform.position.y < 2.25f)
            {
                LLadder.transform.position += new Vector3(0.0f, 0.005f, 0.0f);
            }*/
        }

        // if the player is on the button3
        if (button3.IsTouching(player) || button3.IsTouching(dog))
        {
            // then the button is lowered
            Vector3 temp3 = new Vector3(0.05f, 0.4f, 0.0f);
            button3.transform.position = temp3;
            if (RDoor.transform.position.y > -6.5f)
            {
                RDoor.transform.position += new Vector3(0.0f, -0.005f, 0.0f);
            }
        }
        else
        {
            // raise the button
            Vector3 temp3 = new Vector3(0.05f, 0.6f, 0.0f);
            button3.transform.position = temp3;
            /*if (RDoor.transform.position.y < -2.8f)
            {
                RDoor.transform.position += new Vector3(0.0f, 0.005f, 0.0f);
            }*/
        }

        // if the dog is on the button4
        if (button4.IsTouching(player) || button4.IsTouching(dog))
        {
            // then the button is lowered
            Vector3 temp4 = new Vector3(5.1f, -4.4f, 0.0f);
            button4.transform.position = temp4;
            if (RLadder.transform.position.y > -1.5f)
            {
                RLadder.transform.position += new Vector3(0.0f, -0.005f, 0.0f);
            }
        }
        else
        {
            // raise the button
            Vector3 temp4 = new Vector3(5.1f, -4.2f, 0.0f);
            button4.transform.position = temp4;
            /*if (RLadder.transform.position.y < 2.25f)
            {
                RLadder.transform.position += new Vector3(0.0f, 0.005f, 0.0f);
            }*/
        }
    }
}
