using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFather : MonoBehaviour//Classe que sera pai de todos os inimigos
{
    [SerializeField] private int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Move()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<LifeSystem>())
        {
            collision.gameObject.GetComponent<LifeSystem>().OnDamage(damage);
        }
    }
}
