using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform player;
    public GameObject playeron;
    public Transform dog;
    public GameObject dogon;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (playeron.activeSelf == true)
        {
            Vector3 position = transform.position;
            position.y = (player.position + offset).y;
            transform.position = position;
        }
        if (dogon.activeSelf == true)
        {
            Vector3 position = transform.position;
            position.y = (dog.position + offset).y;
            transform.position = position;
        }
    } 
}
