using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Sprite sprite_sound_on;
    public Sprite sprite_sound_off;

    public Image image;

    public bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        //image = GetComponent<Image>();
        if (image == null) {
            Debug.Log("SoundManager: Composant Image est null");
        }

        // StartSound
        SetSoundMode(isOn);
    }

    public void ToggleSoundMode() {
        isOn = !isOn;
        SetSoundMode(isOn);
    }

    void SetSoundMode(bool isOn) {
        if (isOn) {
            image.sprite = sprite_sound_on; 
            Debug.Log("SoundManager: Son activé");
        } else {
            image.sprite = sprite_sound_off;
            Debug.Log("SoundManager: Son désactivé");
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
