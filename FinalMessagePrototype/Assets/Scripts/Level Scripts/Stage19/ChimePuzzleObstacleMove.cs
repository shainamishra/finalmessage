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

    Vector3 pos;
    float elevation_snapshot = 0;
    //bool still_moving = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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