using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Chrono : MonoBehaviour
{

    public TextMeshProUGUI txt_temps;
    public Image img_state;

    public float nbMinutes;
    
    float timeLeft;
    public float timeToWarning = 5f;

    public bool isPaused;

    public bool isStopped;
    public bool isOver;

    public Sprite sprite_resume;
    public Sprite sprite_pause;

    IEnumerator  IEchrono;

    [HideInInspector]
    public PartieManager partieManager;

    // Start is called before the first frame update
    void Start()
    {
        if (txt_temps == null) {
            Debug.LogError("Chrono: le gameobject est null !");
        }

        timeLeft = nbMinutes * 60;

        IEchrono =  Decount(); 
        StartCoroutine(IEchrono);
    }

    public void SetChronoState() {
        if (!isPaused) { // met le chrono en pause
            StopCoroutine(IEchrono);
            img_state.sprite = sprite_resume;
        } else {    // relance le chrono
            StartCoroutine(IEchrono);
            img_state.sprite = sprite_pause;
        }
        isPaused = !isPaused;
    } 

    string GetSecondsToTimer(float time) {
        int heures = Mathf.Abs((int)time / 3600);
        int minutes = Mathf.Abs((int)(time / 60 -  heures * 60));
        int secondes = Mathf.Abs((int)(time % 60));
        string isNegatif = (int)time < 0  ? "-" : ""; 
        return  isNegatif + (heures > 0 ? heures.ToString() + ":" : "") +  minutes.ToString("D2") + ":" + (secondes).ToString("00");
    }

    // Update is called once per frame
    IEnumerator Decount()
    {
        // Tant qu'on a encore du temps
        while (!isStopped) {

            if (timeLeft < timeToWarning) { 
                txt_temps.color = Color.red;
            } 

            if (!isOver && timeLeft < 0) {
                isOver = true;
                Debug.Log("Chrono fini");
                partieManager.ShowPanelGameOver();
            }

            // on raffraichit le chronomètre
            txt_temps.text = GetSecondsToTimer(timeLeft);
            timeLeft -= Time.deltaTime;
        yield return null;
        }
    }
}
