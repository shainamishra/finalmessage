using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventoryFalchion;
    public GameObject inventoryChimeBells;
    public GameObject inventoryEmberHeart;
    
    public GameObject darkFalchion;
    public GameObject darkChimeBells;
    public GameObject darkEmberHeart;

    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        /*
        inventoryFalchion = gameObject.transform.GetChild(2).gameObject;
        inventoryChimeBells = gameObject.transform.GetChild(3).gameObject;
        inventoryEmberHeart = gameObject.transform.GetChild(4).gameObject;
        
        darkFalchion = gameObject.transform.GetChild(2).gameObject;
        darkChimeBells = gameObject.transform.GetChild(3).gameObject;
        darkEmberHeart = gameObject.transform.GetChild(4).gameObject;
        */

        //canvas = gameObject.GetComponent<Canvas>();

        // aquired
        inventoryFalchion.SetActive(false);
        inventoryChimeBells.SetActive(false);
        inventoryEmberHeart.SetActive(false);

        // dark default
        darkFalchion.SetActive(true);
        darkChimeBells.SetActive(true);
        darkEmberHeart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(test_UI){
            inventoryFalchion.SetActive(true);
            inventoryChimeBells.SetActive(true);
            inventoryEmberHeart.SetActive(true);
        }
        else{
            inventoryFalchion.SetActive(false);
            inventoryChimeBells.SetActive(false);
            inventoryEmberHeart.SetActive(false);
        }
        canvas.worldCamera = Camera.main;
        */

        if(LevelLoader.Key1 == 1)
        {
            inventoryFalchion.SetActive(true);
            darkFalchion.SetActive(false);
        }
        if(LevelLoader.Key2 == 1)
        {
            inventoryChimeBells.SetActive(true);
            darkChimeBells.SetActive(false);
        }
        if(LevelLoader.Key3 == 1)
        {
            inventoryEmberHeart.SetActive(true);
            darkEmberHeart.SetActive(false);
        } 


    }
}
