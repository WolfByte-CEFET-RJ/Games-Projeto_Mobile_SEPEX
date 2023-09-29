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

    [Header("ShootConfigs")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    void Start()
    {
        InvokeRepeating("SearchTarget", 0f, 0.5f);
    }

    void SearchTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies != null)
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
                
                if(distance < shortDistance && distance <= weaponRadius)
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
        if(cronometer < fireRate + 1)//Se cronometro for menor que fireRate+1(o +1 e apenas uma garantia), o cronometer estara contando como um relogio msm
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
                //Metodos para armas melee
            }
            cronometer = 0;
        }   
        
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
        //else if(g.GetComponent<Rocket>())
        //{
        //    g.GetComponent<Rocket>().GetTarget
        //}
    }
    void OnDrawGizmos()//Permite visualizar onde o colisor sera criado
    {
        Gizmos.DrawWireSphere(transform.position, weaponRadius);
    }

  
}
