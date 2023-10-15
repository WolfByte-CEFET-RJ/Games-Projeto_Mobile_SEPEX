using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rodrigo --> bibliotecas a mais
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource soundFX;
    [Header("Audio Clips")]
    public AudioClip musicGame;
    public AudioClip musicMenu;
    public AudioClip hitOnPlayer;
    public AudioClip hitOnEnemy;
    public AudioClip menuBtnIn;
    public AudioClip menuBtnOut;

    public static AudioManager main;    //Rodrigo --> função contendo o script AudioManager que pode ser acessada por outros scripts

    void Awake() {
        main = this;    //Rodrigo --> atribuindo esse script à variável main para chamar as funções em outros scripts
    }

    void Start() {  //Rodrigo --> função Start que checa em qual cena o programa está e toca a música correspondente
        int estado = ChecaCena();
        switch (estado) {   //Rodrigo --> estado = 1 --> cena GameScene .. estado = 2 --> cena MainMenu
            case 1:
                backgroundMusic.clip = musicGame;
                backgroundMusic.Play();
                break;
            case 2:
                backgroundMusic.clip = musicMenu;
                backgroundMusic.Play();
                break;
            default:
                backgroundMusic.Stop();
                break;
        }
    }

    int ChecaCena() {
        if(SceneManager.GetActiveScene().name == "GameScene")
            return 1;
        else if(SceneManager.GetActiveScene().name == "MainMenu")
            return 2;
        else
            return 3;
    }

    public void PlaySFX(AudioClip _clip) {  //Rodrigo --> função que recebe uma das variáveis com clips de áudio e toca uma vez (SFX)
        soundFX.PlayOneShot(_clip);
    }
}
