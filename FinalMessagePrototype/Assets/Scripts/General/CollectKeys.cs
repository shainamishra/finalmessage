using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CollectKeys : MonoBehaviour
{
    public GameObject key;
    public FMOD.Studio.EventInstance pickUpAudio;

    // Start is called before the first frame update
    void Start()
    {   
        pickUpAudio = RuntimeManager.CreateInstance("event:/UI/Item-PickUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.gameObject.SetActive(false);
            if (!AudioManager.isPlaying(pickUpAudio)) {
                pickUpAudio.start();
            }
            if (this.gameObject.name == "WitchKnightKey") 
            {
                LevelLoader.Key4 = 1;
            }
            if (this.gameObject.name == "Falchion")
            {
                LevelLoader.Key1 = 1;
            }
            if (this.gameObject.name == "ChimeStaff")
            {
                LevelLoader.Key2 = 1;
            }
            if (this.gameObject.name == "EmberHeart")
            {
                LevelLoader.Key3 = 1;
            }
        }
    }
}
