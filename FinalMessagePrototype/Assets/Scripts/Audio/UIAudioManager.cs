using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager instance;
    
    [SerializeField]
    public EventReference UIClick;
    private string UIClickEvent = null;

    public void PlayUIClick() {
        if (UIClickEvent != null) {
            RuntimeManager.PlayOneShot(UIClickEvent);
        }
    }

    public EventReference UISoft;
    private string UISoftEvent = null;

    public void PlayUISoft() {
        if (UISoftEvent != null) {
            RuntimeManager.PlayOneShot(UISoftEvent );
        }
    }

    private void Awake() {
        instance = this;
    }
}
