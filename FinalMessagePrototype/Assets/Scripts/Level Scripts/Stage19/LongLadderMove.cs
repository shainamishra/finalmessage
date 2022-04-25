using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongLadderMove : MonoBehaviour
{
    public GameObject button;
    ButtonActivate buttonActivate;
    Vector3 pos;
    public float speed = 30f;
    bool is_on;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonActivate = button.GetComponent<ButtonActivate>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        is_on = buttonActivate.status;
        if(is_on){
            //print("Activated");
            //Move();
            if(pos.y > -6.65){
                pos.y -= speed * Time.deltaTime;
            }
        }
        transform.position = pos;
    }
/*
    void Move(){
        while(pos.y > -6.65){
            pos = transform.position;
            pos.y -= speed * Time.deltaTime;
            transform.position = pos;
        }
    }*/
}
