using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandioseDoorOpen : MonoBehaviour
{
    public bool status;
    public GameObject button1;
    public GameObject button2;

    Collider2D thisDoor;
    Collider2D knight;
    Collider2D dog;
    ButtonActivate button1Activate;
    ButtonActivate button2Activate;
    bool button_trigger;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
        knight = GameObject.Find("Player").GetComponent<Collider2D>();
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        thisDoor = gameObject.GetComponent<Collider2D>();
        button1Activate = button1.GetComponent<ButtonActivate>();
        button2Activate = button2.GetComponent<ButtonActivate>();
        button_trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(button1Activate.status && button2Activate.status){
            //Play big opening animation...
            button_trigger = true;
        }
        if(button_trigger){
            if((thisDoor.IsTouching(knight) || thisDoor.IsTouching(dog)) && Input.GetKeyDown(KeyCode.E)){
                status = true;
            }
            else{
                status = false;
            }
        }
    }
}
