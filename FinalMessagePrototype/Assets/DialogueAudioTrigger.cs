using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DialogueAudioTrigger : MonoBehaviour
{
    public float energy;
    public bool isFM;

    public void playMumbles(string path) {
        FMOD.Studio.EventInstance mumbles = RuntimeManager.CreateInstance(path);
        if (isFM) {
            mumbles.setParameterByName("IsFM", 1);
            mumbles.setParameterByName("Energy", 0.1f);

        } else {
            mumbles.setParameterByName("IsFM", 0);
            mumbles.setParameterByName("Energy", energy);
        }
        mumbles.start();
        mumbles.release();
    }

}
