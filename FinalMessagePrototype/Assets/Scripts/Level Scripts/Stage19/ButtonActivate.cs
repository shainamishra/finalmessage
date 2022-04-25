using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    public bool status;
    
    void OnTriggerEnter2D(Collider2D collider){
        status = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        status = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        status = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
