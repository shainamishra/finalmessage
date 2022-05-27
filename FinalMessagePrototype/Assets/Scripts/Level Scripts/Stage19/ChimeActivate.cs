using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ChimeActivate : MonoBehaviour
{
    public bool status;

    bool overlap;
    bool condition;
    public EventReference chimeAudio;
    public EventReference chimeFail;
    public GameObject chimeGate;
    ChimePuzzle chimePuzzle;

    public void playChime() {
        RuntimeManager.PlayOneShot(chimeAudio);
    }

    public void playFail() {
        RuntimeManager.PlayOneShot(chimeFail);
    }

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
        condition = false;
        status = false;
        chimePuzzle = chimeGate.GetComponent<ChimePuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        // Here's my now standard stacking condition block.
        // Lowest level is to be touching the chime and hit E
        // The next level is to also have the chime staff
        condition = overlap && Input.GetKeyDown(KeyCode.E);
        if(chimePuzzle.requires_key){
            condition = condition && (LevelLoader.Key2 == 1);
        }

        if(condition){
            status = !status;
            playChime();
        } else if (!condition && Input.GetKeyDown(KeyCode.E) && overlap){
            playFail();
        }
    }
}
