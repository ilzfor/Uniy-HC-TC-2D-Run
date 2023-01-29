using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newplayer : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public LayerMask groundLayer;
    private bool isJumping = false;
    private bool facingRight = true;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGround = false;
        }
        else
        {
            vertical = 0;
        }

        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }

        transform.position = transform.position + new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("¦aªO"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("¦aªO"))
        {
            isGround = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
