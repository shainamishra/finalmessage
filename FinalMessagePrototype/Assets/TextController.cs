using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject player_on;
    // public GameObject dog_on;
    public GameObject text_box;
    public GameObject img;
    // public string instruction1 = " ";
    // public string instruction2 = " ";
    // public float transition_point = 0;
    // public bool horizontal_break = true;
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
       
                if(player.transform.position.x > 12){
                    //the text is instruction #1
                    text_box.SetActive(true);
                    img.SetActive(true);
                }
                if(player.transform.position.x > 41){
                    //the text is instruction #1
                    text_box.SetActive(false);
                    img.SetActive(false);
                }
               
    }
}
