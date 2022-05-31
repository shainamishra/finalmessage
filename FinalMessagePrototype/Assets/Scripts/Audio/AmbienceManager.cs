using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class AmbienceManager : MonoBehaviour
{
    
    public static AmbienceManager instance;
    public FMOD.Studio.EventInstance Ambience;
    public float sceneType = 0f;
    public GameObject setAmbience;
    public GameObject ambienceManager;
    public bool onOff;

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(instance);
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    void onSceneLoaded(Scene scene, LoadSceneMode mode) {
        setAmbience = GameObject.Find("AmbienceCheck");
    }

    void Start() {
        ambienceManager = GameObject.Find("Ambience");
        try {
            ambienceManager.SetActive(true);
            Ambience = RuntimeManager.CreateInstance("event:/Environment & Ambience/Ambience");
            RuntimeManager.AttachInstanceToGameObject(Ambience, GetComponent<Transform>(), GetComponent<Rigidbody>());
            Ambience.start();
        }
        catch {
            Ambience.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            ambienceManager.SetActive(false);
        }
    }

    void Update() {
        SceneCheck();
        RuntimeManager.StudioSystem.setParameterByName("Location", sceneType);
    }
    
    void SceneCheck() {
        if (setAmbience.tag == "Terrain: Grass") {
            sceneType = 0f;
        } else if (setAmbience.tag == "Terrain: HighSlopesGrass") {
            sceneType = 1f;
        } else if (setAmbience.tag == "Terrain: Snow") {
            sceneType = 2f;
        } else if (setAmbience.tag == "Terrain: Cave") {
            sceneType = 3f;
        } else if (setAmbience.tag == "Terrain: Stone") {
            sceneType = 4f;
        } else if (setAmbience.tag == "Terrain: Cutscene") {
            sceneType = 5f;
        }
    }

    private void onDestroy() {
        Ambience.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
