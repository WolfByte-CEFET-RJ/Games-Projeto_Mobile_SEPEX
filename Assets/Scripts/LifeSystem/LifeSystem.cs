using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int currentLife;
    private int maxLife;


    public GameObject damageText;
    private enum typeLife
    {
        commonEnemy,
        player,
        boss
    };
    [SerializeField] private typeLife currentType;
    [Header("PlayerSettings")]
    [SerializeField] private Image lifeBar;
    [Header("CommonEnemySettings")]
    [SerializeField] private GameObject coin;
    void Start()
    {
        maxLife = currentLife;
    }
    public void ResetLife()
    {
        currentLife = maxLife;
        lifeBar.fillAmount = (float)currentLife / maxLife;
    }
    public void OnDamage(int dmg)
    {
        
        currentLife -= dmg;
        if(damageText!= null)
        {
            string dano = dmg.ToString();
            var damage = Instantiate(damageText, transform.position, Quaternion.identity);
            damage.SendMessage("SetText", dano);
        }
        if (currentType == typeLife.player)
        {
            lifeBar.fillAmount = (float)currentLife / maxLife;
            Debug.Log("teste");
        }
        if (currentLife <= 0)//Fazer um if pra checar se e player(game over)/inimigo (so morre)/boss(fim da wave)
        {
            if (currentType == typeLife.commonEnemy)
            {
                Instantiate(coin, transform.position, transform.rotation);           
                Destroy(gameObject);
            }
            else if(currentType == typeLife.player)
            {
                GameOver.onGameOver();
                //Animacao de morte??
                Destroy(gameObject);//So lembrando: Em caso de anim de morte: Destroy(gameObject, tempo da anim);
            }
            else
            {
                Destroy(gameObject);
                //Fim da horda
            }
        }
    }
}
