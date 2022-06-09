using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timerChanger : MonoBehaviour
{
    public GameObject regular;
    public GameObject frozen;

    // Start is called before the first frame update
    void Start()
    {
        frozen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7 || SceneManager.GetActiveScene().buildIndex == 8 || SceneManager.GetActiveScene().buildIndex == 12 || SceneManager.GetActiveScene().buildIndex == 13 || SceneManager.GetActiveScene().buildIndex == 17 || SceneManager.GetActiveScene().buildIndex == 18)
        {
            frozen.SetActive(true);
        }
        else 
        {
            frozen.SetActive(false);
        }
    }
}
