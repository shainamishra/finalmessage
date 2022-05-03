using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnAltarTrigger : MonoBehaviour
{
    // Accept relevant targets from Unity editor
    public GameObject altar;
    public float speed = 15f;
    public float target_elevation;

    AltarActivate altarActivate;
    Vector3 pos;
    bool is_on = false;

    // Start is called before the first frame update
    void Start()
    {
        altarActivate = altar.GetComponent<AltarActivate>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        is_on = altarActivate.bark_status && altarActivate.ember_heart_status;
        pos = transform.position;
        if(is_on){
            if(pos.y < target_elevation){
                pos.y += speed * Time.deltaTime;
            }
        }
        transform.position = pos;
    }
}
