using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour//Com certeza esse script nao foi feito seguindo as melhores praticas(dava pra isso tranquilamente ser
//um script pai e 3 filhos), mas como estamos com o tempo apertado, vou tentar refazer ele apenas se sobrar tempo das outras tarefas.
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
    [Header("BossSettings")]
    [SerializeField] private GameObject weaponDropped;
    void Start()
    {
        maxLife = currentLife;
    }
    public void ResetLife()//Metodo exclusivo para player
    {
        currentLife = maxLife;
        lifeBar.fillAmount = (float)currentLife / maxLife;
    }
    void DropWeapon()
    {
        if(weaponDropped != null)
        {
            Instantiate(weaponDropped, transform.position, transform.rotation);
        }
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
                DropWeapon();
                Destroy(gameObject);
                //Fim da horda
            }
        }
    }
}
