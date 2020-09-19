using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxSpeed, speed;
    public bool isGround = false;
    public Animator PlayerAnimator;

    void Start()
    {
        
    }
    
    void Update()
    {

        if (Input.GetKey("right")) {
            speed += 0.006f;
        }else if (Input.GetKey("left"))
        {
            speed -= 0.006f;
        }
        else
        {
            speed *= 0.925f;
            if (Mathf.Abs(speed) <= 0.02f)
            {
                speed = 0;
            }
        }

        if(Input.GetKey(KeyCode.Z))
        {
            PlayerAnimator.SetBool("isPraying", true);
            speed = 0;
        }
        else
        {
            PlayerAnimator.SetBool("isPraying", false);
        }


        PlayerAnimator.SetFloat("speed", Mathf.Abs(speed));
        this.transform.position += new Vector3(speed, 0, 0);
    }
}
