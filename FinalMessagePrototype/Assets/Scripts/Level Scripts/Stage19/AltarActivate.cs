using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AltarActivate : MonoBehaviour
{
    public bool status;
    public bool key_required = true;

    GameObject player;
    GameObject player_on;
    Collider2D player_collider;
    Collider2D altar_collider;

    CrowFlyOff crowFlyOff;
    bool bark_status;

    GameObject ember_heart;
    bool is_on;
    bool isColliding;
    public FMOD.Studio.EventInstance noHeart;

    // Start is called before the first frame update
    void Start()
    {
        status = false;

        player = GameObject.Find("Player");
        player_on = player.transform.GetChild(0).gameObject;
        player_collider = player.GetComponent<Collider2D>();
        altar_collider = gameObject.GetComponent<Collider2D>();

        crowFlyOff = GameObject.Find("Crow").GetComponent<CrowFlyOff>();
        bark_status = false;

        ember_heart = gameObject.transform.GetChild(0).gameObject;
        is_on = false;

        isColliding = false;
        noHeart = RuntimeManager.CreateInstance("event:/Environment & Ambience/ChimeFail");
    }

    // Update is called once per frame
    void Update()
    {
        bark_status = crowFlyOff.status;

        // If you want the key to be required (this is on by default), the the requirements are
        // the crow has been scared of, the knight is currently being controlled, they are in range, they press E, and they have the Ember Heart in their inventory GAAAAAASSSSP...
        // ... otherwise, just the first four of those things (left available for testing purposes)
        if(key_required){
            is_on = bark_status && (player_on.activeSelf == true) && player_collider.IsTouching(altar_collider) && Input.GetKeyDown(KeyCode.E) && (LevelLoader.Key3 == 1);
        }
        else{
            is_on = bark_status && (player_on.activeSelf == true) && player_collider.IsTouching(altar_collider) && Input.GetKeyDown(KeyCode.E);
        }
        
        if(is_on){
            status = true;
            ember_heart.SetActive(true);
            //Debug.Log("Ember Heart on pedestal: " + status);
        } else if (!is_on && isColliding && Input.GetKeyDown(KeyCode.E)) {
            noHeart.start();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            isColliding = false;
        }
    }
}
