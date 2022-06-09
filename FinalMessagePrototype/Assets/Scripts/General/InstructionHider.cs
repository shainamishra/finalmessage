using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionHider : MonoBehaviour
{
    private static bool hidden = false;
    public GameObject instructions;
    public GameObject levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        if(hidden) {
            instructions.gameObject.SetActive(false);
        }
        else {
            if(levelLoader.gameObject.GetComponent<LevelLoader>().getDeathCount() >= 1) {
                hidden = true;
                instructions.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
