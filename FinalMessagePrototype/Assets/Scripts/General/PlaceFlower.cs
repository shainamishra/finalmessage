using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFlower : MonoBehaviour
{
    public bool graveyard;
    public int number;
    public GameObject flower;

    // Start is called before the first frame update
    void Start()
    {
        //access memory for non-graveyard Final Messages
        if(!graveyard) {
            if(number == 7 && LevelLoader.flower7) {flower.gameObject.SetActive(true);}
            else if(number == 8 && LevelLoader.flower8) {flower.gameObject.SetActive(true);}
            else if(number == 10 && LevelLoader.flower10) {flower.gameObject.SetActive(true);}
            else if(number == 12 && LevelLoader.flower12) {flower.gameObject.SetActive(true);}
            else if(number == 13 && LevelLoader.flower13) {flower.gameObject.SetActive(true);}
            else if(number == 18 && LevelLoader.flower18) {flower.gameObject.SetActive(true);}
        }
        else { //access memory for graveyard Final Messages
            if(LevelLoader.graveFlowers[number]) {
                flower.gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void place()
    {
        //edit memory so flower stays placed
        if(!graveyard) {
            if(number == 7) {LevelLoader.flower7 = true;}
            else if(number == 8) {LevelLoader.flower8 = true;}
            else if(number == 10) {LevelLoader.flower10 = true;}
            else if(number == 12) {LevelLoader.flower12 = true;}
            else if(number == 13) {LevelLoader.flower13 = true;}
            else if(number == 18) {LevelLoader.flower18 = true;}
            else {Debug.Log("Error: could not write non-graveyard flower memory.");}
        }
        else {//edit graveyard memory
            LevelLoader.graveFlowers[number] = true;    
        }
        flower.gameObject.SetActive(true);
    }
}
