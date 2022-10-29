using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

    [SerializeField]
    float jumpPower = 5;

    float gravityScale = 10;

    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    bool canJump = true;
    bool jump;

    Vector2 movement;

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
            jump = true;

        //if (Input.GetButtonDown("Sprint"))
        //{
        //    speed += 5;
        //    Debug.Log("sprinting");
        //}
        //else if (Input.GetButtonUp("Sprint"))
        //{
        //    speed = 10;
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        movement = new Vector2(h, 0) * speed;
        movement.y = rb.velocity.y;
        rb.velocity = movement;

        if (jump)
        {
            jump = false;
            canJump = false;
            rb.AddForce(0, jumpPower, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            canJump = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
            canJump = true;
    }
}
