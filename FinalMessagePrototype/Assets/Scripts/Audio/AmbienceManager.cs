using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class AmbienceManager : MonoBehaviour
{
    
    public static AmbienceManager instance;
    public FMOD.Studio.EventInstance Ambience;
    public float scene = 0f;
    public GameObject floor;
    public GameObject ambienceManager;
    public bool onOff;

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(instance);
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    void onSceneLoaded(Scene scene, LoadSceneMode mode) {
        floor = GameObject.Find("Floor");
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
        Ambience.setParameterByName("Location", scene); 
    }
    
    void SceneCheck() {
        if (floor.tag == "Terrain: Grass") {
            scene = 0f;
        } else if (floor.tag == "Terrain: HighSlopesGrass") {
            scene = 1f;
        } else if (floor.tag == "Terrain: Snow") {
            scene = 2f;
        } else if (floor.tag == "Terrain: Cave") {
            scene = 3f;
        } else if (floor.tag == "Terrain: Stone") {
            scene = 4f;
        }
    }

    private void onDestroy() {
        Ambience.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
