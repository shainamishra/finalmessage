using System;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    public EventReference CharacterSwitch;
    private string CharSwitch = null;

    private void Awake() {
        instance = this;
    }

    public void PlayCharSwitchEvent() {
        if (CharSwitch != null) {
            RuntimeManager.PlayOneShot(CharacterSwitch);
        }
    }
}
