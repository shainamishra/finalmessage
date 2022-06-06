using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public GameObject canvas; 

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(26);
    }


    public void Exit()
    {
        Application.Quit();
        // SceneManager.UnloadSceneAsync("1StartScene");
    }
}