using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Classe enregistrant les actions du joueur dans un fichier
    Enregistre la date, le scénario, l'action
    Les logs sont créés à partir des messages consoles (Debug.Log())
 */
public class Logger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }
    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
     void HandleLog(string logString, string stackTrace, LogType type)
    {
        if(type == LogType.Log && logString.Contains("[Log]"))
            {
                logString = logString.Replace("[Log]","");
                Debug.Log("Write in Logger : "+logString);
            }
    }
}
