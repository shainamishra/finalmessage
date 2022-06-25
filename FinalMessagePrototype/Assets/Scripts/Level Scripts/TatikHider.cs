using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TatikHider : MonoBehaviour
{
    private static bool tatik = false;
    public GameObject tatikArar;
    public GameObject levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        if(tatik) {
            tatikArar.gameObject.SetActive(true);
        }
        else {
            if(levelLoader.gameObject.GetComponent<LevelLoader>().getDeathCount() >= 1) {
                tatik = true;
                tatikArar.gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
