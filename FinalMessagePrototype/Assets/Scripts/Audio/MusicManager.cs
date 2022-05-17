using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField]
    public EventReference Music;

    private string MusicEvent = null;

    public void PlayMusic() {
        if (MusicEvent != null) {
            RuntimeManager.PlayOneShot(MusicEvent);
        }
    } 

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(instance);
    }
}
