using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnButtonTrigger : MonoBehaviour
{
    // Accept relevant targets from Unity editor
    public GameObject button;
    public float speed = 3f;
    public float target_rotation;
    public bool clockwise;

    ButtonActivate buttonActivate;
    Vector3 initial_rotation;
    Vector3 rot;
    bool is_on; 

    //float test = 1f;

    // Start is called before the first frame update
    void Start()
    {
        buttonActivate = button.GetComponent<ButtonActivate>();
        initial_rotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        is_on = buttonActivate.status;
        if(is_on){
            if(clockwise){
                RotateClockwise(target_rotation);
            }
            else{
                RotateCounterClockwise(target_rotation);
            }
        }
        /*
        test += speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, test));
        */
    }
    
    void RotateClockwise(float end_rot){
        rot = transform.eulerAngles;
        Debug.Log(rot.z);
        if(rot.z > end_rot){
            rot.z -= speed * Time.deltaTime;
        }
        Debug.Log(rot.z);
        transform.rotation = Quaternion.Euler(rot);
    }

    void RotateCounterClockwise(float end_rot){
        rot = transform.eulerAngles;
        if((rot.z % 360) < end_rot){
            rot.z += speed * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(rot);
    }
}
