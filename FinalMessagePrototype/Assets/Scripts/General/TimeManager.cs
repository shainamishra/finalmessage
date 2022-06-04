using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class TimeManager : MonoBehaviour
{
    public static float startingTime = 300;
    private Text theText;

    public static bool TimesUp = false;
    private static bool timeUp = false;
    public GameObject shadow;
    

    public Animator shadowidle;

    public cameraMovement cameraMovement;
    public playerMovement player;
    public dogMovement dog;


    // public Transform kpos;
    public Transform skpos;
    public GameObject knight;
    public static float speed = 0.000000000000000000000000000000000000000000000001f;

    static TimeManager instance;

    public GameObject thisTimeManager;

    public FMOD.Studio.EventInstance restartAudio;
    public FMOD.Studio.EventInstance timerAudio;
    public FMOD.Studio.EventInstance lowTimeAudio;
    public float timerState = 3f;
    private FMOD.Studio.VCA timeOutVCA;
    // static GameObject ShadowKnight;
 
     void Awake()
     {
         if(instance == null )
         {    
             instance = this; 
            //  ShadowKnight = GameObject.Find("ShadowKnight");// In first scene, make us the singleton.
            //  DontDestroyOnLoad(instance);
         }
         else if(instance != this)
             Destroy(GameObject.Find("Time System"));
            //  Destroy(GameObject.Find("ShadowKnight")); // On reload, singleton already set, so destroy duplicate.
     } 

    void Start()
    {
      // DontDestroyOnLoad(this.gameObject);
      theText = GetComponent<Text>();
      knight = GameObject.Find("Player");
      cameraMovement = GameObject.Find("Main Camera").GetComponent<cameraMovement>();
      player = GameObject.Find("Player").GetComponent<playerMovement>();
      dog = GameObject.Find("Dog").GetComponent<dogMovement>();

      TimesUp = false;
      timeUp = false;
      timeOutVCA = RuntimeManager.GetVCA("vca:/TimeOutAudio");
      restartAudio = RuntimeManager.CreateInstance("event:/UI/Restart");
      timerAudio = RuntimeManager.CreateInstance("event:/UI/Timer");
      lowTimeAudio = RuntimeManager.CreateInstance("event:/UI/LowTimeLoop");
      if (AudioManager.isPlaying(timerAudio)) {
        timerAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
      }


    }

    // Update is called once per frame
    void Update()
    {
        knight = GameObject.Find("Player");
        cameraMovement = GameObject.Find("Main Camera").GetComponent<cameraMovement>();
        player = GameObject.Find("Player").GetComponent<playerMovement>();
        dog = GameObject.Find("Dog").GetComponent<dogMovement>();

        // startingTime -= Time.deltaTime;
        float t = startingTime;
        string min = ((int) t/60).ToString();
        string sec = Mathf.Round((t%60)).ToString();

        //cosmetic changes to the time format
        if(Mathf.Round((t%60))==60) theText.text = (((int) (t/60)+1).ToString()) + ":00";
        else if(Mathf.Round((t%60))<10) theText.text = min + ":0" + sec;
        else theText.text = min + ":" + sec;

        // shadow.SetActive(false);
    

        /*
        if (Input.GetKeyDown(KeyCode.R)){
          // shadow.SetActive(false);
          SceneManager.LoadScene("1StartScene");
          startingTime = 300;
        }
        */
        restart();

        if(startingTime<=0){
          startingTime=0;
          theText.text = "0:00";
          player.moveSpeed = 0;
          dog.moveSpeed = 0;
          TimesUp = true;

          timeOutVCA.setVolume(0f);
          if(cameraMovement.dogon.activeSelf == true){
              cameraMovement.dogon.SetActive(false);
              cameraMovement.playeron.SetActive(true);
            }

            shadow.SetActive(true);
            // skpos.SetPositionAndRotation(new Vector3(knight.transform.position.x+15,knight.transform.position.y,0f),new Quaternion(0,0,0,0));

            // if(skpos.position.x>knight.transform.position.x){
                StartCoroutine(waiter());
                
            // }
            // skpos.SetPositionAndRotation(new Vector3(250f,-1.33f,0f),new Quaternion(0,0,0,0)); 
        }
        
        // if(TimesUp == true && Input.GetKeyDown(KeyCode.R)){
        if(timeUp == true ){
          // shadow.SetActive(false);
          skpos.SetPositionAndRotation(new Vector3(250f,-1.33f,0f),new Quaternion(0,0,0,0));

          TimesUp = false;
          startingTime = 300;
          SceneManager.LoadScene("1StartScene");
          if (!AudioManager.isPlaying(restartAudio)) {
            restartAudio.start();
          }
          timeOutVCA.setVolume(1f);

        }
        Awake();
        slowdown();
        timeCheck();
        timerAudio.setParameterByName("Timer", timerState);

    }

    void timeCheck() {
      if (startingTime <= 150 && startingTime > 146) {
          timerState = 0f;
          if (!AudioManager.isPlaying(timerAudio)) {
            timerAudio.start();
          }
        } else if (startingTime <= 60 && startingTime > 56) {
          timerState = 1f;
          if (!AudioManager.isPlaying(timerAudio)) {
            timerAudio.start();
          }
        } else if (startingTime <= 30 && startingTime > 26) {
          timerState = 2f;
          if (!AudioManager.isPlaying(timerAudio)) {
            timerAudio.start();
          }
        } else if (startingTime <= 10 && startingTime > 0){
          if (!AudioManager.isPlaying(lowTimeAudio)) {
            lowTimeAudio.start();
          } else if (startingTime == 0) {
            timerState = 3f;
          }
        }
    }

    void shadowMove(){
      // //  rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
      //   // Vector2 target = new Vector2(-1f,0f);
      //   // Vector2 path = Vector2.MoveTowards(target,skpos.position,rb.velocity.x);
        // skpos.SetPositionAndRotation(new Vector3(knight.transform.position.x+15,knight.transform.position.y,0f),new Quaternion(0,0,0,0));
        shadowidle.SetTrigger("Start");
        if(skpos.position.x>knight.transform.position.x+15){
          skpos.SetPositionAndRotation(new Vector3(knight.transform.position.x+15,knight.transform.position.y,0f),new Quaternion(0,0,0,0));
          Vector3 path2 = Vector3.MoveTowards(new Vector3(-2f,0,0),skpos.position,speed*Time.deltaTime/100000000000);
          skpos.Translate(path2);

        }


        if(skpos.position.x>knight.transform.position.x+3){
          Vector3 path2 = Vector3.MoveTowards(new Vector3(-0.01f,0,0),skpos.position,speed*Time.deltaTime/100000000000);
          skpos.Translate(path2);
        }

 
    }
    // void shadowLeave() {

    //   if(skpos.position.x <102 && skpos.position.x>15){
    //     // skpos.Rotate(0f, 180f, 0f);
        
    //       Vector3 path1 = Vector3.MoveTowards(new Vector3(6f,0,0),skpos.position,speed*Time.deltaTime/100000000000);
    //       skpos.Translate(path1);


    // }
    // else{
    //       Vector3 path2 = Vector3.MoveTowards(new Vector3(0.01f,0,0),skpos.position,speed*Time.deltaTime/100000000000);
    //       skpos.Translate(path2);
    //     }

    //   }
      


    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    public void slowdown(){
      if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("7FM4_Key3")) 
         {
             startingTime -= 0;
         }
      else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("8FM2")) 
         {
             startingTime -= 0;
         }
      else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("12FM5_Seeker")) 
         {
             startingTime -= 0;
         }
      else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("13FM1_Key2")) 
         {
             startingTime -= 0;
         }
      else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("17Graveyard")) 
         {
             startingTime -= 0;
         }
      else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("18FM_3Key1")) 
         {
             startingTime -= 0;
         }
      else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("21Summit")) 
         {
             startingTime -= 0;
             shadow.SetActive(false);
             thisTimeManager.SetActive(false);
         }
      else {
        startingTime -= Time.deltaTime;
      }
    }

    public IEnumerator waiter()
    {
        //Wait for 10 seconds
        // Debug.Log("Fine. I admit it. I cut in line.");
        // TimesUp = true;
        shadowMove();
        yield return new WaitForSecondsRealtime (9f);
        // Debug.Log("Fine. I admit it. I cut in line.");
        // shadowLeave();
        // Debug.Log("flipped");
        skpos.SetPositionAndRotation(new Vector3(skpos.position.x,skpos.position.y,0f),new Quaternion(0,0,0,0));
        Debug.Log("Leave");
          // startingTime = 300;
          // Debug.Log("Restart");
          timeUp = TimesUp;

        // TimesUp = true;
    }
    
    public static void restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("1StartScene");
            startingTime = 300;
        }
    }
}
