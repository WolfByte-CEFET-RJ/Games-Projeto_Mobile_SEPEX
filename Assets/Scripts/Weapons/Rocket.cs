using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : BulletFather
{
    bool isExploded;
    private int critic;

    public int criticChance;

    void Start()
    {
        isRocket = true;
        rig = GetComponent<Rigidbody2D>();
    }
    void critico()
    {
        critic = Random.Range(1, 100);
        if (criticChance == 5)
        {
            if (critic <= 5)
            {
                critic = 1;
            }
        }
        if (criticChance == 10)
        {
            if (critic <= 10)
            {
                critic = 1;
            }
        }
        if (criticChance == 15)
        {
            if (critic <= 15)
            {
                critic = 1;
            }
        }
        if (criticChance == 20)
        {
            if (critic <= 20)
            {
                critic = 1;
            }
        }
        if (criticChance == 25)
        {
            if (critic <= 25)
            {
                critic = 1;
            }
        }
        if (criticChance == 30)
        {
            if (critic <= 30)
            {
                critic = 1;
            }
        }
        if (criticChance == 35)
        {
            if (critic <= 35)
            {
                critic = 1;
            }
        }
        if (criticChance == 40)
        {
            if (critic <= 40)
            {
                critic = 1;
            }
        }
        if (criticChance == 45)
        {
            if (critic <= 45)
            {
                critic = 1;
            }
        }
        if (criticChance == 50)
        {
            if (critic <= 50)
            {
                critic = 1;
            }
        }
        if (criticChance == 55)
        {
            if (critic <= 55)
            {
                critic = 1;
            }
        }
        if (criticChance == 60)
        {
            if (critic <= 60)
            {
                critic = 1;
            }
        }
        if (criticChance == 65)
        {
            if (critic <= 65)
            {
                critic = 1;
            }
        }
        if (criticChance == 70)
        {
            if (critic <= 70)
            {
                critic = 1;
            }
        }
        if (criticChance == 75)
        {
            if (critic <= 75)
            {
                critic = 1;
            }
        }
        if (criticChance == 80)
        {
            if (critic <= 80)
            {
                critic = 1;
            }
        }
        if (criticChance == 85)
        {
            if (critic <= 85)
            {
                critic = 1;
            }
        }
        if (criticChance == 90)
        {
            if (critic <= 90)
            {
                critic = 1;
            }
        }
        if (criticChance == 95)
        {
            if (critic <= 95)
            {
                critic = 1;
            }
        }
        if (criticChance == 100)
        {
            if (critic <= 100)
            {
                critic = 1;
            }
        }
        if (critic == 1)
        {
            damage = damage * Random.Range(2, 5);
        }
    }
    void resetar()
    {
        damage = 5;
    }

    void FixedUpdate()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<LifeSystem>())
            {
                critico();
                collision.gameObject.GetComponent<LifeSystem>().OnDamage(damage);
                resetar();
            }
            if (!isExploded)
            {
                rig.velocity = Vector2.zero;
                GetComponent<Animator>().Play("RocketExplosion");//O foguete ira explodir a partir dessa animacao
                isExploded = true;//Para garantir que ele exploda apenas uma vez
                damage = (int)(damage * 0.5f);//E quem for pego na explosao, vai perder menos vida que quem foi atingido pelo foguete
            }
            
        }
    }
    
    public void DeleteRocket()//Chamado no AnimationEvent, no fim da animacao da explosao
    {
        Destroy(gameObject);
    }
}
