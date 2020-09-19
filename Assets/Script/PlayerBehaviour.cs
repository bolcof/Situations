using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxSpeed, speed;
    public bool isGround = false;
    public Animator PlayerAnimator;
    
    void Update()
    {

        if (Input.GetKey("right") && isGround) {
            speed += 0.006f;
        }else if (Input.GetKey("left") && isGround)
        {
            speed -= 0.006f;
        }
        else
        {
            if (!isGround)
            {
                speed *= 0.98f;
            }
            else
            {
                speed *= 0.925f;
            }

            if (Mathf.Abs(speed) <= 0.02f)
            {
                speed = 0;
            }
        }

        if (Input.GetKeyDown("up") && isGround)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 13.5f), ForceMode2D.Impulse);
            isGround = false;
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

        this.transform.position += new Vector3(speed, 0, 0);
        if(speed < 0)
        {
            this.gameObject.transform.localScale = new Vector3(-2.25f, 2.25f, 2.25f);
        }
        else if(speed > 0)
        {
            this.gameObject.transform.localScale = new Vector3(2.25f, 2.25f, 2.25f);
        }

        PlayerAnimator.SetFloat("speed", Mathf.Abs(speed));
        PlayerAnimator.SetBool("isGround", isGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
        }
    }
}
