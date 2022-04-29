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
}