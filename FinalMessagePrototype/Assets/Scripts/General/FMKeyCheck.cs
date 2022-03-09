using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FMKeyCheck : MonoBehaviour
{
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        // automatically gives keys to player (for testing)
        /*LevelLoader.Key1 = 1;
        LevelLoader.Key4 = 1;
        LevelLoader.Key2 = 1;*/
    }

    // Update is called once per frame
    void Update()
    {
        // FM1: check for key1, give key 2
        if (SceneManager.GetActiveScene().buildIndex == 12) 
        {
            if (LevelLoader.Key1 == 1) 
            {
                key.SetActive(true);
            }
        }
        // FM3: check for key4, give key 1
        if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            if (LevelLoader.Key4 == 1)
            {
                key.SetActive(true);
            }
        }
        // FM4: check for key2, give key 3
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            if (LevelLoader.Key2 == 1)
            {
                key.SetActive(true);
            }
        }
    }
}
