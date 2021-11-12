using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private static float speed = 50.0f;
    public Rigidbody2D rigidbody2D;
    private static float jumpForce = 140.0f;
    private bool isGrounded = false;
    
    private void Start()
    {
        
    }
    private void Update()
    {
        //move player with w and d keys 
        float h = Input.GetAxis("Horizontal");
        Vector2 dir = new Vector2(h, 0);
        Vector2 movement = dir * speed;

        //secure that movement wont mess up jump
        movement.y = rigidbody2D.velocity.y;
        rigidbody2D.velocity = movement;

        //jump using space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        };

        //flip the character
        if (h == 1) transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (h == -1) transform.localRotation = Quaternion.Euler(0, 180, 0);


    }

    //make sure character jumps only once
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
 
}
