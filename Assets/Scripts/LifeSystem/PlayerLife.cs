using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : LifeSystem
{
    [Header("PlayerSettings")]
    [SerializeField] private Image lifeBar;
    [SerializeField] private Sprite[] lifeSprites;
    public void ResetLife()//Metodo exclusivo para player
    {
        currentLife = maxLife;
        lifeBar.fillAmount = (float)currentLife / maxLife;
        lifeBar.sprite = lifeSprites[currentLife];

    }
    public override void OnDamage(int dmg)
    {
        base.OnDamage(dmg);
        lifeBar.fillAmount = (float)currentLife / maxLife;
        if (currentLife <= 0)
        {
            currentLife = 0;
            GameOver.onGameOver();
            //Animacao de morte??
            Destroy(gameObject);//So lembrando: Em caso de anim de morte: Destroy(gameObject, tempo da anim);
        }
        lifeBar.sprite = lifeSprites[currentLife];
    }
}