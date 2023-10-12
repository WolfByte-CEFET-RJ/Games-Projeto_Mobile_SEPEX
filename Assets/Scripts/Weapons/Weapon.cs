using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("ActualTargetSetters")]
    //[SerializeField] private LayerMask enemyLayer;
    private Transform target;//Em quem a arma vai focar 



    [Header("Weapon configs")]
    [SerializeField] private float weaponRadius;
    [SerializeField] private bool isRanged;
    [SerializeField] private float fireRate;
    private float cronometer;

    [Header("ShootConfigs (Ranged)")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    [Header("AttackCongigs (Melee)")]
    [SerializeField] private int damage;
    [SerializeField] private float knockbackForce;
    private Animator anim;
    private Transform player;
    //private bool isAttacking;

    private int critic;

    [SerializeField] private int criticChance;

    public float WeaponRadius { get => weaponRadius; set => weaponRadius = value; }
    public int CriticChance { get => criticChance; set => criticChance = value; }

    void critico()
    {
        critic = Random.Range(1, 100);
/*
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
*/
        critic = critic <= CriticChance ? 1 : 0;//Versao lowCode para chance de critico
        if (critic == 1)
        {
            damage = damage * Random.Range(2, 15);
        }
    }

    void Start()
    {
        InvokeRepeating("SearchTarget", 0f, 0.25f);
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void SearchTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null)
        {
            float shortDistance = Mathf.Infinity;
            Transform near = null;
            //Para descobrir qual inimigo mais perto, precisamos checar, um a um dos que estão no colisor, qual o que possui a menor distancia do player
            //Com isso, defini o "valor" de infinito para uma variavel que guardara a menor distancia entre um inimigo e o player
            //A cada iteracao, vou checar se a distancia atual e menor que a menor distancia. Se sim(e claro, da primeira vez com certeza), atualizo
            //a variavel shortDistance e a target
            foreach (GameObject e in enemies)
            {
                float distance = Vector3.Distance(transform.position, e.transform.position);

                if (distance < shortDistance && distance <= WeaponRadius)
                {
                    shortDistance = distance;
                    near = e.transform;
                }
            }
            target = near;
        }
        else //Se não existe inimigos nessa layer, então seto o target como null, ja que nao existe inimigos a focar
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cronometer < fireRate + 1)//Se cronometro for menor que fireRate+1(o +1 e apenas uma garantia), o cronometer estara contando como um relogio msm
        {
            cronometer += Time.deltaTime;
        }

        if (!target)//Se o alvo for nulo, paro a leitura do update por aqui mesmo
            return;
        transform.up = (Vector2)(target.position - transform.position);
        if (cronometer >= fireRate)//Se cronometer for maior que fireRate, atiro e reinicio a variavel cronometer
        {
            if (isRanged)
            {
                CreateBullet();
                //Metodos para armas ranged
            }
            else
            {
                BalanceWeapon();
                //Metodos para armas melee
            }
            cronometer = 0;
        }

    }
    void resetar()
    {
        damage = 1;
    }
    void BalanceWeapon()
    {
        anim.SetTrigger("hit");
        
    }
    void CreateBullet()
    {
        GameObject g = Instantiate(bullet, firePoint.position, transform.rotation);
        if(g.GetComponent<BulletFather>())
        {
            g.GetComponent<BulletFather>().GetTarget(target);
        }
        else
        {
            Debug.LogError("Não referenciou nada errado não, colega?\nCertifique-se que o GameObject bullet possui um componente BulletFather");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isRanged && collision.gameObject.tag=="Enemy")
        {
            if (collision.gameObject.GetComponent<LifeSystem>() && collision.gameObject.GetComponent<EnemyFollow>())
            {
                critico();
                EnemyFollow e = collision.gameObject.GetComponent<EnemyFollow>();
                if(!e.GetOnDamage())
                {
                    collision.gameObject.GetComponent<LifeSystem>().OnDamage(damage);
                    StartCoroutine(KnockBack(e));
                }               
                resetar();
            }
        }
    }
    IEnumerator KnockBack(EnemyFollow e)
    {
        e.SetOnDamage(true);
        yield return new WaitForSeconds(fireRate);
        e.SetOnDamage(false);
    }
    
    void OnDrawGizmosSelected()//Permite visualizar onde o colisor sera criado
    {
        Gizmos.DrawWireSphere(transform.position, WeaponRadius);
    }

  
}
