using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public Text damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    public void SetText(string value)
    {
        int dmg;
        int.TryParse(value, out dmg);
        if(dmg> 1 && dmg <8)
        {
            damage.color = Color.yellow;
            damage.text = value;
        }
        else if (dmg > 8)
        {
            damage.color = Color.red;
            damage.text = "Dano Crítico!\n" +value;
        }else
        damage.text = value;
    }
}
