using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioTrigger : MonoBehaviour
{
    public EventReference Event;

    public bool PlayOnAwake;
    public bool PlayOnDestroy;

    public void PlayOneShot() {
        RuntimeManager.PlayOneShot(Event);
    }

    private void Start() {
        if (PlayOnAwake) {
            PlayOneShot();
        }
    }

    private void Stop() {
        if (PlayOnDestroy) {
            PlayOneShot();
        }
    }
}
