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

    public void PlaySound(string path) {
        if (path != null) {
            RuntimeManager.PlayOneShot(path);
            // Debug.Log("Playing!");
        }
    }
}
