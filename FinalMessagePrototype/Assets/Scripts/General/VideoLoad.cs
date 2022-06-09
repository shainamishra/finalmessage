using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.Video;
 using UnityEngine.SceneManagement;

public class VideoLoad : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }
 
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        if(SceneManager.GetActiveScene().buildIndex == 24)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        } 
        else if(SceneManager.GetActiveScene().buildIndex == 25)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(26);
        } 
        /*
        else if(SceneManager.GetActiveScene().buildIndex == 26)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        } 
        */
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
