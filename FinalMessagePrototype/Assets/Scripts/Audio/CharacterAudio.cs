using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CharacterAudio : MonoBehaviour
{

    public void PlayFootsteps(string path) {
        FMOD.Studio.EventInstance Footsteps = RuntimeManager.CreateInstance(path);
        Footsteps.start();
        Footsteps.release();
    }

    public void PlaySecondary(string path) {
        FMOD.Studio.EventInstance Secondary = RuntimeManager.CreateInstance(path);
        Secondary.start();
        Secondary.release();
    }

    public void PlayAction(string path) {
        FMOD.Studio.EventInstance Action = RuntimeManager.CreateInstance(path);
        Action.start();
        Action.release();
    }


}
