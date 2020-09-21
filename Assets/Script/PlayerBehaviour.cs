using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxSpeed, addSpeed, speed;
    private Vector3 defaultScale;
    public bool isGround = false;
    private bool isPrayng = false;
    public Animator PlayerAnimator;

    private void Start()
    {
        defaultScale = this.gameObject.transform.localScale;
    }

    void Update()
    {

        if (Input.GetKey("right") && isGround) {
            speed += addSpeed;
            if (speed > maxSpeed) { speed = maxSpeed; }
        }else if (Input.GetKey("left") && isGround)
        {
            speed -= addSpeed;
            if (speed < -maxSpeed) { speed = -maxSpeed; }
        }
        else
        {
            if (!isGround)
            {
                speed *= 0.98f;
            }
            else
            {
                speed *= 0.9f;
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
            isPrayng = true;
        }
        else
        {
            PlayerAnimator.SetBool("isPraying", false);
        }

        if (isPrayng) { speed = 0; }
        this.transform.position += new Vector3(speed, 0, 0);

        if(speed < 0)
        {
            this.gameObject.transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z);
        }
        else if(speed > 0)
        {
            this.gameObject.transform.localScale = defaultScale;
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

    public void prayEnd()
    {
        isPrayng = false;
    }
}
