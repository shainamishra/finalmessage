using System;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
     private void Awake() {
        instance = this;
    }

    [SerializeField]
    public EventReference CharacterSwitch;
    
    public void PlayCharSwitch(string path) {
        
        if (path != null) {
            RuntimeManager.PlayOneShot(path);
            // Debug.Log("Playing!");
        }
    }

    [SerializeField]
    public EventReference KnightFootsteps;

    public void PlayKnightSteps(string path) {
        FMOD.Studio.EventInstance KnightSteps = RuntimeManager.CreateInstance(path);
        KnightSteps.start();
        KnightSteps.release();
    }

    [SerializeField]
    public EventReference DogFootsteps;

    public void PlayDogSteps(string path) {
        FMOD.Studio.EventInstance DogSteps = RuntimeManager.CreateInstance(path);
        DogSteps.start();
        DogSteps.release();
    }
}
