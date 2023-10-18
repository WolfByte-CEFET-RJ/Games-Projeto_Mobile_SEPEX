using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        /*if(!EventSystem.current.IsPointerOverGameObject())
        {*/
            // Desconsidera iniciar o jogo se clicar em um botão
            if (MenusButtons.main._podeIniciarJogo && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
            {
                // Certifica-se de que está no menu antes de chamar a função
                if (MenusButtons.main.EstouMenu())
                {
                    AudioManager.main.PlaySFX(AudioManager.main.menuBtnIn);   //Rodrigo --> chamando a função PlaySFX para tocar o Button In
                    new WaitForSeconds(2f);
                    MenusButtons.main.ChamaFase("GameScene");
                }
            }
        //}
    }
}
