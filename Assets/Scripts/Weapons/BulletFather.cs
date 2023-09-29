using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFather : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    protected Transform target;
    protected Rigidbody2D rig;
    protected bool isRocket;
    public void GetTarget(Transform tr)
    {
        target = tr;
    }

    protected void Move()
    {
        if (target != null)
            rig.velocity = (target.position - transform.position) * speed * Time.fixedDeltaTime;
        else//Se target nao existir mais, destruir objeto
        {
            if(isRocket)
            {
                rig.velocity = Vector2.zero;
                GetComponent<Animator>().Play("RocketExplosion");
            }
            else
                Destroy(gameObject);
        }
            
    }

}
