using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isGrounded =false;
    private bool isFacingRight =true;

    [SerializeField]private float speed =10.0f;
    [SerializeField] private float jumpForce =1200.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    
      

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    //Physics
    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        
        //Jump code
        if (isGrounded && Input.GetAxis("Jump")>0)
        {
            Jump();
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        // Check if the sprite need to be fliped
        if (isFacingRight && rBody.velocity.x <0)
        {
            Flip();
        }
        else if (!isFacingRight && rBody.velocity.x > 0)
        {
            Flip();
        }

        
        //set Animator
        
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
       
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
       
    }

    private void Jump()
    {
        rBody.AddForce(new Vector2(rBody.velocity.x, jumpForce));
        isGrounded = false;
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }

    
}
