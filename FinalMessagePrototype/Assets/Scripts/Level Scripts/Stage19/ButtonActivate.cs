using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    Collider2D thisButton;
    Collider2D knight;
    Collider2D dog;
    
    public bool status;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
        knight = GameObject.Find("Player").GetComponent<Collider2D>();
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        thisButton = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisButton.IsTouching(knight) || thisButton.IsTouching(dog)){
            status = true;
        }
        else{
            status = false;
        }
    }
}
