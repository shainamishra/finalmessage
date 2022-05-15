using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextChanger : MonoBehaviour
{
    public GameObject player_on;
    public GameObject dog_on;
    public Text text_box;
    public string instruction1 = " ";
    public string instruction2 = " ";
    public float transition_point = 0;
    public bool horizontal_break = true;
    GameObject player;
    GameObject dog;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        dog = GameObject.Find("Dog");
        //player_on = GameObject.Find("PlayerON");
        //dog_on = GameObject.Find("DogON");
    }

    // Update is called once per frame
    void Update()
    {
        //if the knight is being controlled 
        if(player_on.activeSelf == true){
            //and the horizontal position is the one we're concerned about
            if(horizontal_break == true){
                //and they're NOT over the line
                if(player.transform.position.x < transition_point){
                    //the text is instruction #1
                    text_box.text = instruction1;
                }
                else{
                    //the it becomes instruction #2
                    text_box.text = instruction2;
                }
            }
            //else we want the veritcal component
            else{
                if(player.transform.position.y < transition_point){
                    text_box.text = instruction1;
                }
                else{
                    text_box.text = instruction2;
                }
            }
        }
        //else the dog is currently in focus, same rules apply
        if(dog_on.activeSelf == true){
            if(horizontal_break == true){
                if(dog.transform.position.x < transition_point){
                    text_box.text = instruction1;
                }
                else{
                    text_box.text = instruction2;
                }
            }
            else{
                if(dog.transform.position.y < transition_point){
                    text_box.text = instruction1;
                }
                else{
                    text_box.text = instruction2;
                }
            }
        }
    }
}
