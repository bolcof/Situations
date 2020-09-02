using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxSpeed, speed;
    public bool isGround = false;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(speed >= 0.1f)
        {
            speed *= 0.8f;
        }
        else
        {
            speed = 0;
        }

        if (Input.GetKey("right")) {
            speed += 0.05f;
        }

        if (Input.GetKey("left"))
        {
            speed -= 0.05f;
        }

        this.transform.position += new Vector3(speed, 0, 0);
    }
}
