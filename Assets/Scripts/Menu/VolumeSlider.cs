using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rodrigo --> bibliotecas a mais
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] Slider sliderMusica;
    [SerializeField] Slider sliderSFX;
    [Header("Audio Mixer")]
    [SerializeField] AudioMixer myMixer;

    void Start()    //Rodrigo --> função Start que inicia os valores previamente salvos caso existam
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
            myMixer.SetFloat("musica", 0);
        else Load();

        if(!PlayerPrefs.HasKey("sfxVolume"))
            myMixer.SetFloat("sfx", 0);
        else Load();
    }

    public void ChangeVolume(int _estado)   //Rodrigo --> função que controla os sliders recebendo _estado para decidir qual volume é modificado (para manter tudo em um código)
    {   //Rodrigo --> _estado = 1 --> mudança na música ... _estado = 2 --> mudança no sfx
        float volume;
        switch (_estado) {
            case 1:
                volume = sliderMusica.value;    //Rodrigo --> atribui o slider de música à variável volume
                
                //Rodrigo --> modifica o valor (AudioMixer funciona em log, por isso a função Mathf)
                if(volume > 0) myMixer.SetFloat("musica", Mathf.Log10(volume)*20);
                else myMixer.SetFloat("musica", -80);   //Rodrigo --> setando o valor -80dB pois 0dB é o valor máximo
                
                PlayerPrefs.SetFloat("musicVolume", volume);    //Rodrigo --> guardando o valor em PlayerPrefs
                break;
            case 2:
                volume = sliderSFX.value;    //Rodrigo --> atribui o slider de música à variável volume

                //Rodrigo --> modifica o valor (AudioMixer funciona em log, por isso a função Mathf)
                if(volume > 0) myMixer.SetFloat("sfx", Mathf.Log10(volume)*20);
                else myMixer.SetFloat("sfx", -80);   //Rodrigo --> setando o valor -80dB pois 0dB é o valor máximo
                
                PlayerPrefs.SetFloat("sfxVolume", volume);    //Rodrigo --> guardando o valor em PlayerPrefs
                break;
            default:
                break;
        }

    }

    void Load() //Rodrigo --> função para inserir os valores previamente salvos pelo jogador
    {
        sliderMusica.value = PlayerPrefs.GetFloat("musicVolume");
        ChangeVolume(1);
        sliderSFX.value = PlayerPrefs.GetFloat("sfxVolume");
        ChangeVolume(2);
    }
}