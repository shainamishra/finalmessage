using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDisplayController : MonoBehaviour
{
    //Collider2D player;


    void OnTriggerEnter2D(Collider2D collider){
        //if(collider.tag == "PressE"){
            Debug.Log("Here.");
        //}
    }

    void OnTriggerExit2D(Collider2D collider){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("player").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //OnTriggerEnter2D(player);
    }
}
