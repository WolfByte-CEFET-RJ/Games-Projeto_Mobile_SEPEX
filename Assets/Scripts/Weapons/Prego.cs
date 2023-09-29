using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prego : BulletFather
{
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
            Debug.Log("Metodo de tirar vida do inimigo");
            Destroy(gameObject);
        }
    }
}
