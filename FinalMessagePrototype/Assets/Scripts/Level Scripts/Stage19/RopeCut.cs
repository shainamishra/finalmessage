/* A simple script to make the rope an interactable object that releases the elevator.
 * It also "animates" it, by which I mean it stops rendering after a being cut.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RopeCut : MonoBehaviour
{
    public bool requires_key = false;
    public bool crow_can_cut = false;
    public bool status;

    bool is_on;
    bool condition;
    bool isColliding;
    GameObject crow;

    public EventReference ropeFail;
    public FMOD.Studio.EventInstance ropeCut;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
        is_on = false;
        if(crow_can_cut){
            crow = GameObject.Find("Crow");
        }
        ropeCut = RuntimeManager.CreateInstance("event:/Environment & Ambience/RopeSnap");
    }

    public void playRopeFail() {
        RuntimeManager.PlayOneShot(ropeFail);
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
            if (!AudioManager.isPlaying(ropeCut)) {
                    ropeCut.start();
                } 
            
        }
        else if(crow_can_cut) {
            float x_difference = gameObject.transform.position.x - crow.transform.position.x;
            if((x_difference < 0.1) && (x_difference > -0.1)){
                Destroy(gameObject, 0.15f);
                status = true;
                if (!AudioManager.isPlaying(ropeCut)) {
                    ropeCut.start();
                } 
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "StrikeZone"){
            is_on = true;
            if (!condition) {
                playRopeFail();
            }
        }

        if (collider.gameObject.tag == "Player") {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            isColliding = false;
        }
    }
}
