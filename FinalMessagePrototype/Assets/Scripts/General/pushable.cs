using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class pushable : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;
    public GameObject player;
    public GameObject reach;
    GameObject box;

    public EventReference boulderAudio;
    //public FMOD.Studio.EventInstance playBoulder = RuntimeManager.CreateInstance("event:/Environment & Ambience/BoulderPushPull");
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        reach = GameObject.Find("Reach");
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (Input.GetMouseButton(1) == false)
        {
            transform.parent = null;
            //playBoulder.release();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "ReachZone") {
            Debug.Log("Grab");
            transform.parent = player.transform;
            //if (AudioManager.isPlaying(playBoulder)) {
            //    playBoulder.start();
            //}
        } 
        
    }
}
