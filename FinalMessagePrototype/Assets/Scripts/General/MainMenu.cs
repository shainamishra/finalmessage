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
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        canvas.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayUISound() {
        DontDestroyOnLoad(UIAudioManager.instance);
        UIAudioManager.instance.PlayUIClick();
        
    }
}
