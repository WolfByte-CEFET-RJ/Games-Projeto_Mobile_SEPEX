using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prego : BulletFather
{
    private int critic;

    public int criticChance;
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
            damage = damage * Random.Range(2, 10);
        }
    }
    void resetar()
    {
        damage = 1;
    }

    void Start()
    {
        isRocket = false;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(collision.gameObject.GetComponent<LifeSystem>())
            {
                critico();
                collision.gameObject.GetComponent<LifeSystem>().OnDamage(damage);
                resetar();
            }
            Destroy(gameObject);
        }
    }
}
