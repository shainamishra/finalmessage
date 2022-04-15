using System;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
     private void Awake() {
        instance = this;
    }
    
    public void PlayCharSwitch(string path) {
        
        if (path != null) {
            RuntimeManager.PlayOneShot(path);
            // Debug.Log("Playing!");
        }
    }

    
}
