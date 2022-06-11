using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class WitchKill : MonoBehaviour
{
    public Collider2D killBox;
    public Collider2D player;
    public Collider2D dog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.IsTouching(killBox) || dog.IsTouching(killBox)) {
            Kill();
        }
    }

    void Kill() {
        Debug.Log("You died.");
        SceneManager.LoadScene("1StartScene");
        TimeManager.startingTime = 300;
        TimeManager.timeOutVCA.setVolume(1f);
        LevelLoader.deathCount += 1;
    }
}
