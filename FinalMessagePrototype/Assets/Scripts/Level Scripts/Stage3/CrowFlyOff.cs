using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFlyOff : MonoBehaviour
{
    public bool status;

    GameObject dog;
    GameObject dog_on;
    Collider2D dog_collider;
    Collider2D this_collider;
    Vector3 pos;
    Vector3 scale;
    bool bark_status;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("DogPrefab").transform.GetChild(0).gameObject;
        dog_on = dog.transform.GetChild(0).gameObject;
        dog_collider = dog.GetComponent<Collider2D>();
        this_collider = gameObject.GetComponent<Collider2D>();
        status = false;
        bark_status = false;
        scale = transform.localScale;
        scale.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if((dog_on.activeSelf == true) && this_collider.IsTouching(dog_collider) && Input.GetKeyDown(KeyCode.Mouse0)){
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
