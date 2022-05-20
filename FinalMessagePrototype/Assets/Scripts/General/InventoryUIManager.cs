using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    GameObject inventoryFalchion;
    GameObject inventoryChimeStaff;
    GameObject inventoryEmberHeart;

    //public bool test_UI = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryFalchion = gameObject.transform.GetChild(1).gameObject;
        inventoryChimeStaff = gameObject.transform.GetChild(2).gameObject;
        inventoryEmberHeart = gameObject.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(test_UI){
            inventoryFalchion.SetActive(true);
            inventoryChimeStaff.SetActive(true);
            inventoryEmberHeart.SetActive(true);
        }
        else{
            inventoryFalchion.SetActive(false);
            inventoryChimeStaff.SetActive(false);
            inventoryEmberHeart.SetActive(false);
        }
        */

        if(LevelLoader.Key1 == 1){
            inventoryFalchion.SetActive(true);
        }
        if(LevelLoader.Key2 == 1){
            inventoryChimeStaff.SetActive(true);
        }
        if(LevelLoader.Key3 == 1){
            inventoryEmberHeart.SetActive(true);
        } 
    }
}
