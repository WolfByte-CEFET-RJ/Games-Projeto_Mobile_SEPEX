using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private int[] conters = new int[3];//0-velocidade; 1-critico; 2-alcance
    [SerializeField] private Sprite[] statusBar;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSpeedAtribute(Image i)//0
    {
        if(conters[0] < statusBar.Length-1)
        {
            conters[0]++;
            i.sprite = statusBar[conters[0]];
        }
        
    }
    public void UpdateCriticAtribute(Image i)//1
    {
        if (conters[1] < statusBar.Length-1)
        {
            conters[1]++;
            i.sprite = statusBar[conters[1]];
        }           
    }
    public void UpdateRangeAtribite(Image i)//2
    {
        if (conters[2] < statusBar.Length-1)
        {
            conters[2]++;
            i.sprite = statusBar[conters[2]];
        }           
    }
}
