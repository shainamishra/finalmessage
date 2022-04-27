using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimePuzzle : MonoBehaviour
{
    Transform chime1;
    Transform chime2;
    Transform chime3;
    ChimeActivate chimeActivate1;
    ChimeActivate chimeActivate2;
    ChimeActivate chimeActivate3;

    bool level_one = false;
    bool level_two = false;
    bool level_three = false;
    bool control1 = false;
    bool control2 = false;
    bool control3 = false;

    // Start is called before the first frame update
    void Start()
    {
        chime1 = transform.Find("Chime1");
        chime2 = transform.Find("Chime2");
        chime3 = transform.Find("Chime3");
        chimeActivate1 = chime1.GetComponent<ChimeActivate>();
        chimeActivate2 = chime2.GetComponent<ChimeActivate>();
        chimeActivate3 = chime3.GetComponent<ChimeActivate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WhichChanged() == 1){
            level_one = true;
            Debug.Log("Level one");
        }
        if(level_one && (WhichChanged() == 2)){
            level_two = true;
            Debug.Log("Level two");
        }
        if(level_two && (WhichChanged() == 3)){
            level_three = true;
            Debug.Log("Level Three");
        }

        if(level_one && level_two && level_three){
            Debug.Log("Puzzle Solved!");
        }

        if(Input.GetKeyDown(KeyCode.E)){
            chimeActivate1.status = false;
            chimeActivate2.status = false;
            chimeActivate3.status = false;
        }
    }

    int WhichChanged(){
        if(chimeActivate1.status != control1){
            Debug.Log("Chime one changed.");
            control1 = chimeActivate1.status;
            return 1;
        }
        else if(chimeActivate2.status != control2){
            Debug.Log("Chime two changed.");
            control2 = chimeActivate2.status;
            return 2;
        }
        else if(chimeActivate3.status != control3){
            Debug.Log("Chime three changed.");
            control3 = chimeActivate3.status;
            return 3;
        }
        else{
            control1 = chimeActivate1.status;
            control2 = chimeActivate2.status;
            control3 = chimeActivate3.status;
            return 0;
        }
    }
}
