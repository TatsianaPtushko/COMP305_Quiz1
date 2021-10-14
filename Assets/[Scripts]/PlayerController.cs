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
    [SerializeField] private float jumpForce =500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    //Ladder variables
    private float vert;
    [SerializeField] private float ySpeed = 3f;
    public bool isClimb = false;
    public bool bottomLadder = false;
    public bool topLadder = false;
    public Ladder ladder;
    private float initialGravity;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        initialGravity = rBody.gravityScale;
    }

    //Physics
    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        //Jump code
        if(isGrounded && Input.GetAxis("Jump")>0)
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

        if (isClimb)
        {    rBody.gravityScale = 0f;
             rBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.0f)
            {   
                transform.position = new Vector3(ladder.transform.position.x, rBody.position.y);
                Climb();
            }
        }
        else
        {
            rBody.gravityScale = initialGravity;
        }


        //set Animator
        
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isClimb", isClimb);
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

    private void Climb()
    {
        //if (Input.GetAxis("Jump") > 0.1f)
        //{

        //    rBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        //    isClimb = false;
        //    rBody.gravityScale = initialGravity;
        //    Jump();
        //    return;
        //}
        anim.speed = 0f;
        vert = Input.GetAxis("Vertical");
        //Climbing up
        if (vert >0.1f && !topLadder)
        {
            rBody.velocity = rBody.velocity = new Vector2(0f, vert * ySpeed);
            anim.speed = 1f;
           
        }
        //Climbing down
        else if(vert < -0.1f && !bottomLadder)
        {
            rBody.velocity = rBody.velocity = new Vector2(0f, vert * ySpeed);
            anim.speed = 1f;
            
        }
        //Stay still
        else
        {   
            anim.speed = 0f;
            rBody.velocity = Vector2.zero;
            
        }
    }

}
