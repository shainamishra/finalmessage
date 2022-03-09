using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeys : MonoBehaviour
{
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        
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
