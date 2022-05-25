using System;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public static bool isPlaying(FMOD.Studio.EventInstance instance) {
        FMOD.Studio.PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }

    private void Awake() {
        instance = this;
    }
    
    public void PlaySound(string path) {
        
        if (path != null) {
            RuntimeManager.PlayOneShot(path);
        }
    }


    
}
