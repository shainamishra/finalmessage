using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnCrowTrigger : MonoBehaviour
{
    public GameObject StaffInNest;
    public GameObject StaffOnRope;
    public GameObject ChimeStaffFreed;
    public GameObject FalchionCord;
    CrowFlyOff crowFlyOff;
    RopeCut ropeCut;
    bool control = true;

    // Start is called before the first frame update
    void Start()
    {
        crowFlyOff = GameObject.Find("Crow").GetComponent<CrowFlyOff>();
        ropeCut = FalchionCord.GetComponent<RopeCut>();
    }

    // Update is called once per frame
    void Update()
    {
        if(crowFlyOff.status){
            StaffInNest.SetActive(false);
            // Control is just here to stop it constantly re-rendering
            if(control){
                StaffOnRope.SetActive(true);
            }
            if(!ropeCut.status){
                FalchionCord.SetActive(true);
            }
        }
        if(ropeCut.status && control){
            StaffOnRope.SetActive(false);
            ChimeStaffFreed.SetActive(true);
            control = false;
        }
    }
}
