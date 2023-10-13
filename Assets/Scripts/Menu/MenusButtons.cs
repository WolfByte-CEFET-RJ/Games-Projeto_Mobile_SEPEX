using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenusButtons : MonoBehaviour
{
    private bool _podeIniciarJogo = true;

    void Update()
    {
        if (_podeIniciarJogo && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            // Desconcidera iniciar o jogo se clicar em um botão
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // Certifica-se de que está no menu antes de chamar a função
                if (EstouMenu())
                {
                    ChamaFase("GameScene");
                }
            }
        }
    }

    //Verica se está no menu para poder chamar
    private bool EstouMenu()
    {
        return SceneManager.GetActiveScene().name == "MainMenu";
    }

    // Função de chamar qualquer cena
    public void ChamaFase(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    // Função de sair do jogo
    public void SairJogo()
    {
        Application.Quit();
    }
}
