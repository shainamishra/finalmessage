using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float max_height;
    public float min_height;
    public float speed;
    public bool is_moving_up;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
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
}
