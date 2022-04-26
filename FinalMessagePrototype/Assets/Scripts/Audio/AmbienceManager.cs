using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AmbienceManager : MonoBehaviour
{
    
    public static AmbienceManager instance;

    [SerializeField]
    public EventReference Ambience;
    private string AmbienceEvent = null;

    public void PlayAmbience() {
        if (AmbienceEvent != null) {
            RuntimeManager.PlayOneShot(AmbienceEvent);
        }
    } 

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(instance);
    }

}
