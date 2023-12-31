using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private VariableJoystick varJoy;//A variavel do Joystick mobile
    private Rigidbody2D rig;
    [SerializeField]private SpriteRenderer sprite;

    public float Speed { get => speed; set => speed = value; }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float xAxis = varJoy.Horizontal * Speed * Time.fixedDeltaTime;
        float yAxis = varJoy.Vertical * Speed * Time.fixedDeltaTime;
        rig.velocity = new Vector2(xAxis, yAxis);//Pegando os valores da horizontal e da vertical do joystick e passando eles na velocidade do Player

        if (xAxis > 0)
        {
            sprite.flipX = false;
        }
        else if (xAxis < 0)
        {
            sprite.flipX = true;
        }
    }

}
