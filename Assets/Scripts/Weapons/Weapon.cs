using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("ActualTargetSetters")]
    [SerializeField] private LayerMask enemyLayer;
    private Transform target;//Em quem a arma vai focar 
    

    [Header("Weapon configs")]
    [SerializeField] private float weaponRadius;

    [SerializeField] private bool isRanged;

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
                float distance = Mathf.Abs(Vector3.Distance(transform.position, e.transform.position));
                
                if(distance < shortDistance && distance <=weaponRadius)
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
        if (!target)
            return;

        transform.up = (Vector2)(target.position - transform.position);
        if (isRanged)
        {
            //Metodos para armas ranged
        }
        else
        {
            //Metodos para armas melee
        }
    }

    void OnDrawGizmos()//Permite visualizar onde o colisor sera criado
    {
        Gizmos.DrawWireSphere(transform.position, weaponRadius);
    }

  
}
