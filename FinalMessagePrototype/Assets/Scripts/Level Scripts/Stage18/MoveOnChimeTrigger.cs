/* I sloppily coppied this from MoveOnButtonTrigger, so it might have
 * idiosyncracies, so to speak.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnChimeTrigger : MonoBehaviour
{
    // Accept relevant targets from Unity editor
    public GameObject button;
    public float speed = 30f;
    public float target_elevation;

    public bool second_button = false;
    public GameObject button_2;

    ChimeActivate buttonActivate;
    ChimeActivate buttonActivate2;
    Vector3 initial_position;
    Vector3 pos;
    bool is_on; 
    
    // Start is called before the first frame update
    void Start()
    {
        buttonActivate = button.GetComponent<ChimeActivate>();
        if(second_button){
            buttonActivate2 = button_2.GetComponent<ChimeActivate>();
        }
        initial_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If this object is controlled by two buttons at once, do that
        // Else, just the first one
        if(second_button){
            is_on = (buttonActivate.status && buttonActivate2.status);
        }
        else{
            is_on = buttonActivate.status;
        }
        // If target elevation is above the initial position, move up first and then down
        // Else, go down first and then up
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
        if(pos.y < end_pos){
            pos.y += speed * Time.deltaTime;
        }
        transform.position = pos;
    }

    void MoveDown(float end_pos){
        pos = transform.position;
        if(pos.y > end_pos){
            pos.y -= speed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
