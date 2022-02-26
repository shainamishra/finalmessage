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

    public float[] _xClamp;
    //public float[] _yClamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // focus on the knight
        if (playeron.activeSelf == true)
        {
            float xClamp = Mathf.Clamp(player.position.x, _xClamp[0], _xClamp[1]);
            //float yClamp = Mathf.Clamp(player.position.y, _yClamp[0], _yClamp[1]);
            transform.position = new Vector3(xClamp, (player.position + offset).y, transform.position.z);
            /*Vector3 position = transform.position;
            position.y = (player.position + offset).y;
            transform.position = position;*/
        }
        // focus on the dog
        if (dogon.activeSelf == true)
        {
            float xClamp = Mathf.Clamp(dog.position.x, _xClamp[0], _xClamp[1]);
            //float yClamp = Mathf.Clamp(dog.position.y, _yClamp[0], _yClamp[1]);
            transform.position = new Vector3(xClamp, (dog.position + offset).y, transform.position.z);
            /*Vector3 position = transform.position;
            position.y = (dog.position + offset).y;
            transform.position = position;*/
        }
    } 
}
