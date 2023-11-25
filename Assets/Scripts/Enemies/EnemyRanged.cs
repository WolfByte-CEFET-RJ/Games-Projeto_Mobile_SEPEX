using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyFather//Lembrar de mudar a logica para invokeRepeating, usando o radius e o metodo Distance
{
    private Transform playerPos;
    private EnemyFollow move;
    [SerializeField] private GameObject targetObj;

    [SerializeField] private GameObject bullet;

    private bool onAttack;
    private float radius;
    void Start()
    {
        move = GetComponent<EnemyFollow>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        targetObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !onAttack)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        onAttack = true;

        Vector3 target = playerPos.position;
        targetObj.transform.position = target;
        targetObj.SetActive(true);
        move.Speed = 0;
        yield return new WaitForSeconds(1f);
        Debug.Log(Instantiate(bullet, target, transform.rotation));
        move.Speed = move.getInitialSpeed();
        targetObj.SetActive(false);

        onAttack = false;
    }
}
