/* This script animates the basic behavior of the moving obstacles: to oscillate up and down
 * This can be disabled by a trigger using the public variable is_on.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float max_height;
    public float min_height;
    public float speed;
    public bool is_moving_up;

    public bool is_on = true;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(is_on){
            Oscillate();
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
}
