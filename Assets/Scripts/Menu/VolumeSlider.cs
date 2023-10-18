using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rodrigo --> bibliotecas a mais
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider thisSlider;
    [SerializeField] int state;

    void Start(){
        switch (state){     //Rodrigo --> state = 1 (música) state = 2 (sfx)
            case 1:
                ChangeSlider(PlayerPrefs.GetFloat("musicVolume"));
                break;
            case 2:
                ChangeSlider(PlayerPrefs.GetFloat("sfxVolume"));
                break;
            default:
                break;
        }
    }

    void ChangeSlider(float _value){
        thisSlider.value = _value;
    }

    void ChangeVolume(int _estado){
        AudioManager.main.ChangeVolume(_estado, thisSlider.value);
        Start();
    }

}