using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public GameObject door;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // osilates the door up and down
        float y = Mathf.PingPong(Time.time * speed, 1) * 3 - 2;
        door.transform.position = new Vector3(0, y, 0);
    }
}
