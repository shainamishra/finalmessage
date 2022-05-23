using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script is SPECIFICALLY for button animation as of 5/23 - Chantel 

public class ButtonCollision : MonoBehaviour
{
    public Collider2D dog;
    public Collider2D player;

    public Collider2D button;
    
    public SpriteRenderer ButtonUp;
    public SpriteRenderer ButtonDown;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<Collider2D>();
        
        //button = GameObject.Find("Button").GetComponent<Collider2D>();

        ButtonUp = GameObject.Find("ButtonUp").GetComponent<SpriteRenderer>();
        ButtonDown = GameObject.Find("ButtonDown").GetComponent<SpriteRenderer>();

        ButtonDown.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if the dog is on the button
        if (button.IsTouching(dog) || button.IsTouching(player))
        {
            // then the button is lowered
            ButtonUp.enabled = false;
            ButtonDown.enabled = true;
        }
        else
        {
            // raise the button
            ButtonUp.enabled = true;
            ButtonDown.enabled = false;
        }
    }
}
