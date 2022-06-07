using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLoader : MonoBehaviour
{
    GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // destroy pause menu after summit
        if(SceneManager.GetActiveScene().buildIndex == 21)
        {
            pause = GameObject.Find("PauseMenu");
            Destroy(pause);
        }
    }
}
