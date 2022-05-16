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
    

    public Animator shadowidle;

    public cameraMovement cameraMovement;


    // public Transform kpos;
    public Transform skpos;
    public GameObject knight;
    public static float speed = 0.000000000000000000000000000000000000000000000001f;

    static TimeManager instance;
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
        knight = GameObject.Find("PlayerPrefab");
        cameraMovement = GameObject.Find("Main Camera").GetComponent<cameraMovement>();
        TimesUp = false;


    }

    // Update is called once per frame
    void Update()
    {
        knight = GameObject.Find("PlayerPrefab");
        cameraMovement = GameObject.Find("Main Camera").GetComponent<cameraMovement>();

        startingTime -= Time.deltaTime;
        float t = startingTime;
        string min = ((int) t/60).ToString();
        string sec = Mathf.Round((t%60)).ToString();

        //cosmetic changes to the time format
        if(Mathf.Round((t%60))==60) theText.text = (((int) (t/60)+1).ToString()) + ":00";
        else if(Mathf.Round((t%60))<10) theText.text = min + ":0" + sec;
        else theText.text = min + ":" + sec;

        // shadow.SetActive(false);
    

        if (Input.GetKeyDown(KeyCode.R)){
          // shadow.SetActive(false);
          SceneManager.LoadScene("1StartScene");
          startingTime = 300;
        }

        if(startingTime<=0){
          startingTime=0;
          theText.text = "0:00";
          if(cameraMovement.dogon.activeSelf == true){
              cameraMovement.dogon.SetActive(false);
              cameraMovement.playeron.SetActive(true);
            }

            shadow.SetActive(true);
            
            if(skpos.position.x>knight.transform.position.x+5){

                StartCoroutine(waiter());
                
            }
            // skpos.SetPositionAndRotation(new Vector3(250f,-1.33f,0f),new Quaternion(0,0,0,0));

            TimesUp = true;
            
        }
        

        if(TimesUp == true && Input.GetKeyDown(KeyCode.R)){
          // shadow.SetActive(false);
          skpos.SetPositionAndRotation(new Vector3(250f,-1.33f,0f),new Quaternion(0,0,0,0));

          TimesUp = false;
          startingTime = 300;
          SceneManager.LoadScene("1StartScene");

        } 
        Awake();

    }

    void shadowMove(){
      // //  rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
      //   // Vector2 target = new Vector2(-1f,0f);
      //   // Vector2 path = Vector2.MoveTowards(target,skpos.position,rb.velocity.x);
        
        if(skpos.position.x>knight.transform.position.x+20){
          // Vector3 path1 = Vector3.MoveTowards(new Vector3(-20f,0,0),skpos.position,speed*Time.deltaTime/100000000000);
          skpos.Translate(new Vector3(-10,0,0));
        }
        else{
          shadowidle.SetTrigger("Start");
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

    public IEnumerator waiter()
    {
        //Wait for 10 seconds
        // Debug.Log("Fine. I admit it. I cut in line.");
        shadowMove();
        yield return new WaitForSecondsRealtime (8f);
        // Debug.Log("Fine. I admit it. I cut in line.");
        // shadowLeave();
        // Debug.Log("flipped");
        skpos.SetPositionAndRotation(new Vector3(skpos.position.x,skpos.position.y,0f),new Quaternion(0,0,0,0));
        Debug.Log("Leave");
          // startingTime = 300;
          // Debug.Log("Restart");
        
        

    }
}
