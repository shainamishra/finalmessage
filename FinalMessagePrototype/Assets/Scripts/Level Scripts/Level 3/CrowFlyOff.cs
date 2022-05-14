using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFlyOff : MonoBehaviour
{
    public GameObject dog_on;
    bool bark_status;
    bool overlap;
    Vector3 pos;
    Vector3 scale;

    void OnTriggerEnter2D(Collider2D collider){
        overlap = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        overlap = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        overlap = false;
        scale = transform.localScale;
        scale.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if((dog_on.activeSelf == true) && overlap && Input.GetKeyDown(KeyCode.Mouse0)){
            bark_status = true;
            Debug.Log("Woof activated");
        }
        if(bark_status){
            transform.localScale = scale;
            pos = transform.position;
            pos.y += 5 * Time.deltaTime;
            pos.x += 10 * Time.deltaTime;
            transform.position = pos;
            Destroy(gameObject, 5);
        }
    }
}
