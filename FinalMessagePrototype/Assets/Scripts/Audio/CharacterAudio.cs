using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CharacterAudio : MonoBehaviour
{
   [SerializeField]
    public EventReference Footsteps;

    public void PlayFootsteps(string path) {
        FMOD.Studio.EventInstance Footsteps = RuntimeManager.CreateInstance(path);
        Footsteps.start();
        Footsteps.release();
    }


}
