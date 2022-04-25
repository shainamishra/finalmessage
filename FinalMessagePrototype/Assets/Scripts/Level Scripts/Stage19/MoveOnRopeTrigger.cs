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
    Vector3 pos;
    bool is_on = false;

    // Start is called before the first frame update
    void Start()
    {
        ropeCut = rope.GetComponent<RopeCut>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        is_on = ropeCut.status;
        pos = transform.position;
        if(is_on){
            if(pos.y < target_elevation){
                pos.y += speed * Time.deltaTime;
            }
        }
        transform.position = pos;
    }
}
