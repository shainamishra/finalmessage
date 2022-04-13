using System;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
     private void Awake() {
        instance = this;
    }

    // [SerializeField]
    // public EventReference CharacterSwitch;
    
    public void PlayCharSwitch(string path) {
        
        if (path != null) {
            RuntimeManager.PlayOneShot(path);
            // Debug.Log("Playing!");
        }
    }
}
