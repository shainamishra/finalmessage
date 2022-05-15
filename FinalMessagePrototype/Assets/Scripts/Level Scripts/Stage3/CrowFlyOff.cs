using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFlyOff : MonoBehaviour
{
    public GameObject dog_on;
    public bool status;

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
        status = false;
        overlap = false;
        bark_status = false;
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
            // send signal to activated stuff
            status = true;
            // Move off as if flying
            transform.localScale = scale;
            pos = transform.position;
            pos.y += 5 * Time.deltaTime;
            if(scale.x < 0){
                pos.x += 10 * Time.deltaTime;
            }
            else{
                pos.x -= 10 * Time.deltaTime;
            }
            transform.position = pos;

            // Play flying animation would go here, I think? <---

            // Remove from scene after flying off
            Destroy(gameObject, 5);
        }
    }
}
