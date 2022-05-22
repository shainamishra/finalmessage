using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BoulderAudio : MonoBehaviour
{
    public GameObject player;
    public GameObject dog;

    public EventReference boulderAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        dog = GameObject.Find("Dog");
    }

    public void playBoulderAudio() {
        RuntimeManager.PlayOneShot(boulderAudio);
    }

    void onCollisionEnter(Collision boulderCollision) {
        if (boulderCollision.gameObject.name == "Player" || boulderCollision.gameObject.name == "Dog") {
            playBoulderAudio();
            Debug.Log("BRRRRRR");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
