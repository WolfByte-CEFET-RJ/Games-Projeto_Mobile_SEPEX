using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Credits : MonoBehaviour
{
    public float velocidade = 1.0f;
    private RectTransform textoCreditosRectTransform;
    public float limitePosicaoY = 628.0f;
    public string nomeMenuScene = "MainMenu";

    private void Start()
    {
        textoCreditosRectTransform = GetComponent<RectTransform>();
    }

    //Sobe o texto dos creditos
    void Update()
    {
        Vector3 newPosition = textoCreditosRectTransform.anchoredPosition + (Vector2.up * velocidade * Time.deltaTime);
        textoCreditosRectTransform.anchoredPosition = newPosition;

        if (textoCreditosRectTransform.anchoredPosition.y >= limitePosicaoY)
            SceneManager.LoadScene("MainMenu");
    }
}
