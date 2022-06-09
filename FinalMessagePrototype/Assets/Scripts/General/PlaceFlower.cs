using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFlower : MonoBehaviour
{
    private static bool placed = false;
    public GameObject flower;

    // Start is called before the first frame update
    void Start()
    {
        if(placed) {
            flower.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void place()
    {
        placed = true;
        flower.gameObject.SetActive(true);
    }
}
