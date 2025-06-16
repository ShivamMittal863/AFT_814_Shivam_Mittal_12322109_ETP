using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float move;
    private int jumpCount;
    private bool isGrounded;
    private Rigidbody2D rb;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        move = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetBool("isJumping", !isGrounded);

        if (move > 0)
        {
            transform.localScale = new Vector3 (5,5,5);
        }

        else if (move < 0)
        {
            transform.localScale = new Vector3 (-5,5,5);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            if (isGrounded || jumpCount < 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount++;
            }



    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (move * moveSpeed , rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
