using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ButtonActivate : MonoBehaviour
{
    public bool rock_in_scene;
    public bool status;

    Collider2D thisButton;
    Collider2D knight;
    Collider2D dog;
    Collider2D rock;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
        knight = GameObject.Find("Player").GetComponent<Collider2D>();
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        thisButton = gameObject.GetComponent<Collider2D>();
        if(rock_in_scene){
            rock = GameObject.Find("Rock").GetComponent<Collider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rock_in_scene){
            if(thisButton.IsTouching(knight) || thisButton.IsTouching(dog) || thisButton.IsTouching(rock)){
                status = true;
            }
            else{
                status = false;
            }
        }
        else{
            if(thisButton.IsTouching(knight) || thisButton.IsTouching(dog)){
                status = true;
            }
            else{
               status = false;
            }
        }
    }
}
