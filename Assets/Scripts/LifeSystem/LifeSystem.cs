using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int maxLife;
    private int currentLife;
    void Start()
    {
        currentLife = maxLife;
    }

    public void OnDamage(int dmg)
    {
        currentLife -= dmg;
        if(currentLife <= 0)//Fazer um if pra checar se e player(game over)/inimigo (so morre)/boss(fim da wave)
        {
            Destroy(gameObject);
        }
    }
}
