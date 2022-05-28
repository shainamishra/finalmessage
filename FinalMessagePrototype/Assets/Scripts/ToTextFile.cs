using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ToTextFile : MonoBehaviour
{
    // Start is called before the first frame update
    public Text finalMessage;

    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/YourFinalMessage/");
    }

    // Update is called once per frame
    void Update()
    {
        if (finalMessage.text == ""){
            return;
        }
        string txtFileName = Application.streamingAssetsPath + "/YourFinalMessage/" + "YourFinalMessage" + ".txt";

        if (!File.Exists(txtFileName)){
            File.WriteAllText(txtFileName, "Your Final Message: \n\n");

        }
        if (Input.GetKeyDown(KeyCode.Return)){
            File.AppendAllText(txtFileName, finalMessage.text + "\n");

        }
        
    }
}
