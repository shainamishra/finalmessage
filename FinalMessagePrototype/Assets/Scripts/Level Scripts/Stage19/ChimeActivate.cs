using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeActivate : MonoBehaviour
{
    bool overlap;
    public bool status;

    void OnTriggerEnter2D(Collider2D collider){
        overlap = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        overlap = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        overlap = false;
        status = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(overlap && Input.GetKeyDown(KeyCode.X)){
            if (LevelLoader.Key2 == 1)
            {
                if (status == false)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            //Debug.Log("Ding..." + status);
        }
    }
}
