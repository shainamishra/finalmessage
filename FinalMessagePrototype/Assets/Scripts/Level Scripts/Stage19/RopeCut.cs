/* A simple script to make the rope an interactable object that releases the elevator.
 * It also "animates" is, by which I mean it stops rendering after a being cut.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{
    //public GameObject strikeZone;
    public bool requires_key = false;
    public bool status;

    //Collider2D strikeZoneCollider;
    //Collider2D thisRope;
    bool is_on;
    bool condition;

    // Start is called before the first frame update
    void Start()
    {
        /*
        status = false;
        strikeZone = GameObject.Find("StrikeZone").GetComponent<Collider2D>();
        thisRope = gameObject.GetComponent<Collider2D>();
        /*
        if(requires_key){
            condition = (collider.gameObject.name == "StrikeZone") && (LevelLoader.Key1 == 1);
        }
        else{
            condition = (collider.gameObject.name == "StrikeZone");
        }
        */
        status = false;
        is_on = false;
        //thisRope = gameObject.GetComponent<Collider2D>();
        //strikeZoneCollider = strikeZone.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(requires_key){
            condition = is_on && (LevelLoader.Key1 == 1);
        }
        else{
            condition = is_on;
        }

        if(condition){
            Destroy(gameObject, 0.15f);
            status = true;
        }
        /*
        thisRope = gameObject.GetComponent<Collider2D>();
        if(thisRope.IsTouching(strikeZone)){
            Destroy(gameObject, 0.15f);
            status = true;
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "StrikeZone"){
            is_on = true;
        }
    }
}
