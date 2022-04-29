using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject canvas; 

    public void StartGame()
    {
        Debug.Log("start");
        SceneManager.LoadScene(24);
    }

    public void Settings()
    {
        Debug.Log("settings");
        canvas.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void PlayUISound() {
        DontDestroyOnLoad(UIAudioManager.instance);
        UIAudioManager.instance.PlayUIClick();
        
    }
}
