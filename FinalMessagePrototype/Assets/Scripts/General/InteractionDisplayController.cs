using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDisplayController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "PressE"){
            Debug.Log("Here.");
        }
    }

    public void OnTriggerExit2D(Collider2D collider){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
