using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour
{
    private bool _podeIniciarJogo = true;

    void Update()
    {
        if (_podeIniciarJogo && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            // Desconcidera iniciar o jogo se clicar em um botão
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                InicioJogo();
            }
        }
    }

    // Função de iniciar o jogo
    public void InicioJogo()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Função de sair do jogo
    public void SairJogo()
    {
        Application.Quit();
    }
}
