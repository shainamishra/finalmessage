using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnRopeTrigger : MonoBehaviour
{
    // Accept relevant targets from Unity editor
    public GameObject rope;
    public float speed = 15f;
    public float target_elevation;

    RopeCut ropeCut;
    Vector3 initial_position;
    Vector3 pos;
    bool is_on = false;

    // Start is called before the first frame update
    void Start()
    {
        ropeCut = rope.GetComponent<RopeCut>();
        initial_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        is_on = ropeCut.status;
        if(is_on){
            if( (target_elevation-initial_position.y) > 0){
                MoveUp(target_elevation);
            }
            else{
                MoveDown(target_elevation);
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
