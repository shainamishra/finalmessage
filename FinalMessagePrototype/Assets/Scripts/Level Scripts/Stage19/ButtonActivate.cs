using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ButtonActivate : MonoBehaviour
{
    public bool rock_in_scene;
    public bool another_rock;
    public bool status;

    Collider2D thisButton;
    Collider2D knight;
    Collider2D dog;
    Collider2D rock;
    Collider2D rock_1;
    
    SpriteRenderer spriteRenderer;
    // These two are set in the prefab in the editor, cause they won't find for some reason...
    public Sprite button_up;
    public Sprite button_down;

    bool condition;

    public FMOD.Studio.EventInstance buttonAudio;
    public float onOff; 
    

    // Start is called before the first frame update
    void Start()
    {
        status = false;
        knight = GameObject.Find("Player").GetComponent<Collider2D>();
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        thisButton = gameObject.GetComponent<Collider2D>();
        if(rock_in_scene){
            rock = GameObject.Find("Rock").GetComponent<Collider2D>();
            if(another_rock){
                rock_1 = GameObject.Find("Rock (1)").GetComponent<Collider2D>();
            }
        }
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        condition = false;
        onOff = 0f;
        buttonAudio = RuntimeManager.CreateInstance("event:/Environment & Ambience/ButtonPress");
    }

    // Update is called once per frame
    void Update()
    {
        // If the knight OR the dog is touching, the button turns on
        // Then if there's a rock, OR it with the previous condition
        // Then if there's another rock, OR it with the previous condition
        condition = thisButton.IsTouching(knight) || thisButton.IsTouching(dog);
        if(rock_in_scene){
            condition = condition || thisButton.IsTouching(rock);
            if(another_rock){
                condition = condition || thisButton.IsTouching(rock_1);
            }
        }

        if(condition){
            spriteRenderer.sprite = button_down;
            status = true;
            // onOff = 1f;
            // if (!AudioManager.isPlaying(buttonAudio)) {
            //     buttonAudio.setParameterByName("OnOff", onOff);
            //     buttonAudio.start();
            // } else {
            //     buttonAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            // }
        }
        else{
            spriteRenderer.sprite = button_up;
            status = false;
            // onOff = 0f;
            // if (!AudioManager.isPlaying(buttonAudio)) {
            //     buttonAudio.setParameterByName("OnOff", onOff);
            //     buttonAudio.start();
            // } else {
            //     buttonAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            // }
        }
    }

    // private void onCollisionEnter2D(Collider2D other) {
    //     Debug.Log("trigger!");
    //     if (other.gameObject.tag == "Player" || other.gameObject.tag == "Rock") {
    //         if (!AudioManager.isPlaying(buttonAudio)) {
    //             buttonAudio.setParameterByName("OnOff", onOff);
    //             buttonAudio.start();
    //             Debug.Log("start playing");
    //         } else {
    //             buttonAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    //             Debug.Log("stop playing");
    //         }
    //     }
    // }
}
