using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarActivate : MonoBehaviour
{
    //public GameObject dog;
    public GameObject dog_on;
    public GameObject player_on;
    public bool bark_status;
    public bool ember_heart_status;
    bool overlap;

    void OnTriggerEnter2D(Collider2D collider){
        overlap = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        overlap = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //dog = GameObject.Find("Dog");
        overlap = false;
        bark_status = false;
        ember_heart_status = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((dog_on.activeSelf == true) && overlap && Input.GetKeyDown(KeyCode.Mouse0)){
            bark_status = true;
            Debug.Log("Woof activated: " + bark_status);
        }

        // if the player has the ember heart
        //if (LevelLoader.Key3 == 1) {
            if (bark_status && (player_on.activeSelf == true) && overlap && Input.GetKeyDown(KeyCode.E)) {
                ember_heart_status = true;
                Debug.Log("Ember Heart on pedestal: " + ember_heart_status);
            }
        //}
    }
}
