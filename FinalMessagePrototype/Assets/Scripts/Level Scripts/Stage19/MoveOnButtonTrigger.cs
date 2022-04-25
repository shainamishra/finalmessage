/* This script can be attached to any object that needs to move triggered by a button.
 * It will accept a button in the scene, the speed at which it needs to move, and an elevtion to move to from the editor.
 *
 * Behavior:
 * While a character stands on the associated button, this object will move (either up or down) to the designated
 * elevation within the scene. If the character steps off the button, it will return to its initial position.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnButtonTrigger : MonoBehaviour
{
    // Accept relevant targets from Unity editor
    public GameObject button;
    public float speed = 30f;
    public float target_elevation;

    ButtonActivate buttonActivate;
    Vector3 initial_position;
    Vector3 pos;
    bool is_on; 
    
    // Start is called before the first frame update
    void Start()
    {
        buttonActivate = button.GetComponent<ButtonActivate>();
        initial_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If target elevation is above the initial position, move up first and then down
        // Else, go down first and then up
        is_on = buttonActivate.status;
        if( (target_elevation-initial_position.y) > 0){
            if(is_on){
                MoveUp(target_elevation);
            }
            else{
                MoveDown(initial_position.y);
            }
        }
        else{
            if(is_on){
                MoveDown(target_elevation);
            }
            else{
                MoveUp(initial_position.y);
            }
        }
    }

    void MoveUp(float end_pos){
        pos = transform.position;
        is_on = buttonActivate.status;
        if(pos.y < end_pos){
            pos.y += speed * Time.deltaTime;
        }
        transform.position = pos;
    }

    void MoveDown(float end_pos){
        pos = transform.position;
        is_on = buttonActivate.status;
        if(pos.y > end_pos){
            pos.y -= speed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
