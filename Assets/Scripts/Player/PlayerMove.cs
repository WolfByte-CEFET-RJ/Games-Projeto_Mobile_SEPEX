using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private VariableJoystick varJoy;
    private Rigidbody2D rig;
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
        float xAxis = varJoy.Horizontal * speed * Time.fixedDeltaTime;
        float yAxis = varJoy.Vertical * speed * Time.fixedDeltaTime;
        rig.velocity = new Vector2(xAxis, yAxis);

        if (xAxis > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (xAxis < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
