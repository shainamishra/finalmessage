/* A simple script to make the rope an interactable object that releases the elevator.
 * It also "animates" it, by which I mean it stops rendering after a being cut.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{
    public bool requires_key = false;
    public bool crow_can_cut = false;
    public bool status;

    bool is_on;
    bool condition;
    GameObject crow;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
        is_on = false;
        if(crow_can_cut){
            crow = GameObject.Find("Crow");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Since this script is also used on the Falchion Cord,
        // this block makes it modular by allowing the user to 
        // turn the key requirement on and off as needed
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
        else if(crow_can_cut){
            float x_difference = gameObject.transform.position.x - crow.transform.position.x;
            if((x_difference < 0.1) && (x_difference > -0.1)){
                Destroy(gameObject, 0.15f);
                status = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "StrikeZone"){
            is_on = true;
        }
    }
}
