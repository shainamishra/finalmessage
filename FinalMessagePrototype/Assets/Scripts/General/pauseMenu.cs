using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject canvas; 

    public Button pause; 
    public Button play; 
    
    // Start is called before the first frame update
    void Start()
    {
        // start button listeners
        Button pauseBTN = pause.GetComponent<Button>();
        pauseBTN.onClick.AddListener(pauseTask);

        // continue button listeners
        Button playBTN = play.GetComponent<Button>();
        playBTN.onClick.AddListener(playTask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pauseTask()
    {
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
        canvas.gameObject.SetActive(true);
    }

    void playTask()
    {
        pause.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
        TimeManager.startingTime = 300;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
