using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    public static float startingTime = 300;
    private Text theText;

    public static bool TimesUp = false;
    public GameObject shadow;

    public playerMovement player;
    
    public dogMovement dog;

    public Rigidbody2D rb;
    public Transform kpos;
    public Transform skpos;
    public static float speed = 0.000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001f;
    // public Animator transition;
    
    private float moveDirection = 0f;
        private float moveSpeed = 0.000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001f;



    // Start is called before the first frame update
    // private void Awake()
    // {
    //     rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    // }
    void Start()
    {
      // DontDestroyOnLoad(this.gameObject);
      
        theText = GetComponent<Text>();
        TimesUp = false;


    }

    // Update is called once per frame
    void Update()
    {
        startingTime -= Time.deltaTime;
        float t = startingTime;
        string min = ((int) t/60).ToString();
        string sec = Mathf.Round((t%60)).ToString();

        //cosmetic changes to the time format
        if(Mathf.Round((t%60))==60) theText.text = (((int) (t/60)+1).ToString()) + ":00";
        else if(Mathf.Round((t%60))<10) theText.text = min + ":0" + sec;
        else theText.text = min + ":" + sec;

        shadow.SetActive(false);
    

        if (Input.GetKeyDown(KeyCode.R)){
          // shadow.SetActive(false);
          SceneManager.LoadScene("1StartScene");
          startingTime = 300;
        }

        if(startingTime<=0){
          startingTime=0;
          
          theText.text = "0:00";
          player.moveSpeed = 0;
          dog.moveSpeed = 0;
          TimesUp = true;
          
          
          // transition.SetTrigger("Start");
          // transition.Play("Crossfade_End",-1,0.25f);
            shadow.SetActive(true);
            if(skpos.position.x>-0.9){

                shadowMove();
            }
            // transition.StopPlayback();
        }

        if(TimesUp == true && Input.GetKeyDown(KeyCode.R)){
          // shadow.SetActive(false);
          TimesUp = false;
          startingTime = 300;
          SceneManager.LoadScene("1StartScene");

        } 
    }

    void shadowMove(){
       rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        // Vector3 path = Vector3.MoveTowards(new Vector3(-1,0,0),skpos.position,speed*Time.deltaTime/10000000000000000);
        Vector2 target = new Vector2(-1f,0f);
        Vector2 path = Vector2.MoveTowards(target,skpos.position,rb.velocity.x);

        skpos.Translate(path);
    }


    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
