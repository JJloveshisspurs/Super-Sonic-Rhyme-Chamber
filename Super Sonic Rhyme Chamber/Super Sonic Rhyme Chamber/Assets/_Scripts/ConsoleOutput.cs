using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleOutput : MonoBehaviour
{
//#if !UNITY_EDITOR
             static string myLog = "";
             public string output;
             public string stack;
    public TextMeshProUGUI consoleText;
     
             void OnEnable()
             {
                 Application.logMessageReceived += Log;
             }
     
             void OnDisable()
             {
                 Application.logMessageReceived -= Log;
             }
     
             public void Log(string logString, string stackTrace, LogType type)
             {
                 output = logString;
                 stack = stackTrace;
                 myLog = output + "\n" + myLog;
                 if (myLog.Length > 5000)
                 {
                     myLog = myLog.Substring(0, 4000);
                 }

                    SetConsoleTextLabel();
             }
     
             void SetConsoleTextLabel()
             {
                
                     consoleText.text = myLog;
                 
             }
     //#endif
         
}
