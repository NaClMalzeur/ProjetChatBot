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
    public Sprite sprite_resume;
    public Sprite sprite_pause;

    IEnumerator  IEchrono;

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
        int heures = (int)time / 3600;
        int minutes = (int)(time / 60 -  heures * 60);
        int secondes = (int)(time % 60);

        return (heures > 0 ? heures.ToString() + ":" : "") +  minutes.ToString("D2") + ":" + (secondes).ToString("00");//.0").Replace(",", ".");
    }

    // Update is called once per frame
    IEnumerator Decount()
    {

        // Tant qu'on a encore du temps
        while (timeLeft > 0) {

            if (timeLeft < timeToWarning) 
                txt_temps.color = Color.red;

            // on raffraichit le chronomètre
            txt_temps.text = GetSecondsToTimer(timeLeft);
            timeLeft -= Time.deltaTime;
        yield return null;
        }

        // notifie la fin du chrono
        Debug.Log("Chrono fini");
        txt_temps.text = GetSecondsToTimer(0f);
    }
}
