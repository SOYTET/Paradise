using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementButton : MonoBehaviour
{
    bool isRight;
    bool isLeft;
    bool isJump;
    bool isGround;
    bool isMoving;

    public float MoveSpeed = 5f;
    public float JumpHight = 5f;
    void Start()
    {
        transform.position = Vector3.right * 0.0f;
        transform.position = Vector3.left * 0.0f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        isGround = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRight)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(+MoveSpeed, rb.velocity.y);

            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (rb.velocity.x > 1f)
            {
                isMoving = true;
                Animator ani = GetComponent<Animator>();
                ani.Play("Run");
            }
        }
        if (isLeft)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-MoveSpeed, rb.velocity.x);

            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (rb.velocity.x < 2f)
            {
                isMoving = true;
                Animator ani = GetComponent<Animator>();
                ani.Play("Run");
            }
        }
        if (isJump && isGround)
        {
            isGround = false;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 8f);

            if (rb.velocity.y > 1f)
            {
                isMoving = true;
                Animator ani = GetComponent<Animator>();
                ani.Play("Jump");
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("onGround");
        }
    }
    public void pointerDownRight()
    {
        isRight = true;
    }
    public void pointerUpRight()
    {
        isRight = false;
    }
    public void pointerDownLeft()
    {
        isLeft = true;
    }
    public void pointerUpLeft()
    {

        isLeft = false;
    }
    public void pointerDownJump()
    {
        isJump = true;
    }
    public void pointerUpJump()
    {

        isJump = false;
    }
}
