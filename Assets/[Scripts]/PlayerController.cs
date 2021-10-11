using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rBody;
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = 0.0f;
        float y =0.0f;

        if (isGrounded)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Jump");
        }


        Vector2 movementVector = new Vector2(x* horizontalForce, y* verticalForce);
        rBody.AddForce(movementVector);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}
