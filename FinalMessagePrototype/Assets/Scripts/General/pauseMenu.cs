using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject canvas; 

    public Button pause; 
    public Button play; 

    LevelLoader LL;
    
    // Start is called before the first frame update
    void Start()
    {
        // start button listeners
        Button pauseBTN = pause.GetComponent<Button>();
        pauseBTN.onClick.AddListener(pauseTask);

        // continue button listeners
        Button playBTN = play.GetComponent<Button>();
        playBTN.onClick.AddListener(playTask);

        // find level loader
        LL = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (play.gameObject.activeInHierarchy == true)
        {
            Debug.Log("play on");
        }
        else
        {
            Debug.Log("play off");
            pause.gameObject.SetActive(true);
        }
    }

    void pauseTask()
    {
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
        canvas.gameObject.SetActive(true);
    }

    void playTask()
    {
        play.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
    }

    void ResetGame()
    {
        //TimeManager.startingTime = 300;
        //LevelLoader.deathCount += 1;
        //SceneManager.LoadScene(1);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
