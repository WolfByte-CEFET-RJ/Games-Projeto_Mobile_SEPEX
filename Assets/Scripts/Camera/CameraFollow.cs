using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    
    public void FixedUpdate()
    {
        if(player)
            transform.position = Vector2.Lerp(transform.position, player.position, 0.2f);
    }
}
