using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxSpeed, addSpeed, speed;
    private Vector3 defaultScale;
    public bool isGround = false;
    private bool isPrayng = false;
    private bool isHitRightWall = false, isHitLeftWall = false;
    public Animator PlayerAnimator;

    [SerializeField]
    private float firstLockTime;
    public bool isEnabled = false;
    private float time = 0.0f;

    private void Start()
    {
        defaultScale = this.gameObject.transform.localScale;
    }

    void Update()
    {

        time += Time.deltaTime;
        if (time > firstLockTime) { isEnabled = true; }

        if (isEnabled)
        {
            if (Input.GetKey("right") && isGround && !isHitRightWall)
            {
                speed += addSpeed;
                if (speed > maxSpeed) { speed = maxSpeed; }
            }
            else if (Input.GetKey("left") && isGround && !isHitLeftWall)
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

            if (Input.GetKeyDown("up") && isGround && !isPrayng)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 13.5f), ForceMode2D.Impulse);
                isGround = false;
            }

            if (Input.GetKey(KeyCode.Z) && isGround)
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

            if (speed < 0)
            {
                this.gameObject.transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z);
            }
            else if (speed > 0)
            {
                this.gameObject.transform.localScale = defaultScale;
            }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("rightWall"))
        {
            isHitRightWall = true;
        }else if (collision.gameObject.name == ("leftWall"))
        {
            isHitLeftWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("rightWall"))
        {
            isHitRightWall = false;
        }
        else if (collision.gameObject.name == ("leftWall"))
        {
            isHitLeftWall = false;
        }
    }

    public void prayEnd()
    {
        isPrayng = false;
    }
}
