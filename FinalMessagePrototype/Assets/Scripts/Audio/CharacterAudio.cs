using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CharacterAudio : MonoBehaviour
{
    private float distance = 5f;
    private float Material;

    void FixedUpdate() {
        TerrainCheck();
        Debug.DrawRay(transform.position, Vector2.down*distance, Color.red);
    }

    void TerrainCheck() {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, distance, 1 << 6);

        if (hit.collider) {
            if (hit.collider.tag == "Terrain: Grass") {
                Material = 0f;
            } else if (hit.collider.tag == "Terrain: Snow") {
                Material = 1f;
            } else if (hit.collider.tag == "Terrain: Cave") {
                Material = 2f;
            }  else if (hit.collider.tag == "Terrain: Stone") {
                Material = 4f;
            } else {
                Material = 0f;

            }
        }

    }
    
    public void PlayFootsteps(string path) {
        FMOD.Studio.EventInstance Footsteps = RuntimeManager.CreateInstance(path);
        Footsteps.setParameterByName("Material", Material);
        Footsteps.start();
        Footsteps.release();
    }

    public void PlaySecondary(string path) {
        FMOD.Studio.EventInstance Secondary = RuntimeManager.CreateInstance(path);
        Secondary.start();
        Secondary.release();
    }

    public void PlayAction(string path) {
        FMOD.Studio.EventInstance Action = RuntimeManager.CreateInstance(path);
        Action.start();
        Action.release();
    }


}
