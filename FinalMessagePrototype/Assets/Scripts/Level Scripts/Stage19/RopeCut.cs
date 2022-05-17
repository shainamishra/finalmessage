/* A simple script to make the rope an interactable object that releases the elevator.
 * It also "animates" it, by which I mean it stops rendering after a being cut.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{
    public bool requires_key = false;
    public bool status;

    bool is_on;
    bool condition;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
        is_on = false;
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
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "StrikeZone"){
            is_on = true;
        }
    }
}
