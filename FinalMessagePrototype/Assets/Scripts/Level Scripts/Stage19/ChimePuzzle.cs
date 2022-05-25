/* Okay, so this script is a little odd looking, but it's pretty simple in concept.
 * It's a standard brute force puzzle, like Simon: players have to hit the chimes in a certain order.
 * If the mess up the order, they have to start over.
 * I managed this in probably the least elegant way possible, but it's workable for a small number of variations.
 * If we want more variations or a longer version, we'll revisit it.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimePuzzle : MonoBehaviour
{
    public bool requires_key = true;
    //Grab the Chime children of this object
    public Transform first_chime;
    public Transform second_chime;
    public Transform third_chime;
    ChimeActivate chimeActivate1;
    ChimeActivate chimeActivate2;
    ChimeActivate chimeActivate3;

    //Grab the obstacle objects, assigned in the editor
    public GameObject Obstacle_1;
    public GameObject Obstacle_2;
    public GameObject Obstacle_3;
    ChimePuzzleObstacleMove obstacleMove1;
    ChimePuzzleObstacleMove obstacleMove2;
    ChimePuzzleObstacleMove obstacleMove3;
    
    //Instantiate control variables
    bool control1 = false;
    bool control2 = false;
    bool control3 = false;
    int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        chimeActivate1 = first_chime.GetComponent<ChimeActivate>();
        chimeActivate2 = second_chime.GetComponent<ChimeActivate>();
        chimeActivate3 = third_chime.GetComponent<ChimeActivate>();
        obstacleMove1 = Obstacle_1.GetComponent<ChimePuzzleObstacleMove>();
        obstacleMove2 = Obstacle_2.GetComponent<ChimePuzzleObstacleMove>();
        obstacleMove3 = Obstacle_3.GetComponent<ChimePuzzleObstacleMove>();

        //print("State = " + state);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Okay, so this is where things get kinda complicated...
        Basically, we advance from state 0 (start) to state 3 (puzzle complete) one at a time.
        To do this, we check the status of the current chime against its status in the last call of update() (control1/2/3)
        If the proper bell for this state is activated, stop the associated obstacle and advance the state by 1
        Else, reset everything to state 0
        */

        if(state == 0){
            if(chimeActivate1.status != control1){
                obstacleMove1.is_on = false;
                state++;
                //Debug.Log("State = " + state);
            }
            else if( (chimeActivate2.status != control1) || (chimeActivate3.status != control2)){
                StartOver();
                //Debug.Log("State = " + state);
            }
        }
        else if(state == 1){
            if(chimeActivate2.status != control2){
                obstacleMove2.is_on = false;
                state++;
                //Debug.Log("State = " + state);
            }
            else if( (chimeActivate1.status != control1) || (chimeActivate3.status != control3)){
                StartOver();
                //Debug.Log("State = " + state);
            }
        }
        else if(state == 2){
            if(chimeActivate3.status != control3){
                obstacleMove3.is_on = false;
                state++;
                //Debug.Log("State = " + state);
            }
            else if( (chimeActivate1.status != control1) || (chimeActivate2.status != control2)){
                StartOver();
                //Debug.Log("State = " + state);
            }
        }
        control1 = chimeActivate1.status;
        control2 = chimeActivate2.status;
        control3 = chimeActivate3.status;
    }

    //Pretty self-expanatory: this resets everything.
    void StartOver(){
        chimeActivate1.status = false;
        chimeActivate2.status = false;
        chimeActivate3.status = false;
        state = 0;
        obstacleMove1.is_on = true;
        obstacleMove2.is_on = true;
        obstacleMove3.is_on = true;
        //Debug.Log("Start Over.");
    }
}
