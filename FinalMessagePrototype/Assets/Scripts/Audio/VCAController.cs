using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class VCAController : MonoBehaviour
{
    private FMOD.Studio.VCA VcaController;
    public string VcaName;

    private Slider slider;

    void Start() {
        VcaController = RuntimeManager.GetVCA("vca:/" + VcaName);
        slider = GetComponent<Slider>();
    }

    public void SetVolume(float volume) {
        VcaController.setVolume(volume);
    }
}
