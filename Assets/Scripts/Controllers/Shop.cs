using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private int[] conters = new int[3];//0-velocidade; 1-critico; 2-alcance
    [SerializeField] private Sprite[] statusBar;
    // Start is called before the first frame update
    private PlayerCoin coins;
    private void Start()
    {
        coins = FindObjectOfType<PlayerCoin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSpeedAtribute(Image i)//0
    {
        if(conters[0] < statusBar.Length-1)
        {
            if(coins.GetCoins() >= 5)
            {
                conters[0]++;
                i.sprite = statusBar[conters[0]];
                coins.SetCoins(5, 0);
            }
            else{
                Debug.LogError("Sem dinheiro para essa arma\nJoel-Em breve faco a logica visual desse aviso");
            }
        }
        
    }
    public void UpdateCriticAtribute(Image i)//1
    {
        if (conters[1] < statusBar.Length-1)
        {
            if(coins.GetCoins() >= 10)
            {
                conters[1]++;
                i.sprite = statusBar[conters[1]];
                coins.SetCoins(10, 1);
            }
            else
            {
                Debug.LogError("Sem dinheiro para essa arma\nJoel-Em breve faco a logica visual desse aviso");
            }

        }           
    }
    public void UpdateRangeAtribite(Image i)//2
    {
        if (conters[2] < statusBar.Length-1)
        {
            if (coins.GetCoins() >= 10)
            {
                conters[2]++;
                i.sprite = statusBar[conters[2]];
                coins.SetCoins(10, 2);
            }
            else
            {
                Debug.LogError("Sem dinheiro para essa arma\nJoel-Em breve faco a logica visual desse aviso");
            }
        }           
    }
}
