/* This script handles on half of the chime gate puzzle mechanic, the other
 * half being done in "ChimePuzzle.cs". This essentially has two modes, one
 * that is identical to "ObstacleMove.cs" and one that is the same as
 * "MoveOnButtonTrigger.cs". These are set automatically provided the tags
 * of the respective ojects are set correctly. This script handles moving the
 * obstacles themselves. ChimePuzzle handles turning them off and on.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimePuzzleObstacleMove : MonoBehaviour
{
    public float max_height;
    public float min_height;
    public float speed;
    public bool is_moving_up;

    public bool is_on = true;
    public float target_elevation;

    Vector3 initial_position;
    Vector3 pos;
    float elevation_snapshot = 0;

    // Start is called before the first frame update
    void Start()
    {
        initial_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "MovingObstacle"){
            MovingObstacleUpdate();
        }
        else if(gameObject.tag == "ObstacleDoor"){
            ObstacleDoorUpdate();
        }
    }

    void MovingObstacleUpdate(){
        if(is_on){
            elevation_snapshot = 0;
            Oscillate();
        }
        else{
            if(elevation_snapshot == 0){
                elevation_snapshot = transform.position.y;
            }
            if(target_elevation < elevation_snapshot){
                MoveDown(target_elevation);
            }
            else{
                MoveUp(target_elevation);
            }
        }
    }

    void ObstacleDoorUpdate(){
        if( (target_elevation-initial_position.y) > 0){
            if(is_on == false){
                MoveUp(target_elevation);
            }
            else{
                MoveDown(initial_position.y);
            }
        }
        else{
            if(is_on == false){
                MoveDown(target_elevation);
            }
            else{
                MoveUp(initial_position.y);
            }
        }
    }

    void Oscillate(){
        pos = transform.position;
        if(is_moving_up){
            if(pos.y < max_height){
                pos.y += speed * Time.deltaTime;
            }
            else{
                is_moving_up = false;
            }
        }
        else{
            if(pos.y > min_height){
                pos.y -= speed * Time.deltaTime;
            }
            else{
                is_moving_up = true;
            }
        }
        transform.position = pos;
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