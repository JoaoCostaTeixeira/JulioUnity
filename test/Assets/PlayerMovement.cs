using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float grafity = -11f;
    public float speed = 12f;
    Vector3 velocity;

    public Transform gorundCheck;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;

    public LayerMask groundMaks;
    bool sprint = false;

    bool isGrounded;
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(gorundCheck.position, groundDistance, groundMaks);


        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            sprint = false;
        }

        if (isGrounded)
        {
            if (sprint)
            {
                speed = 24f;
            }
            else
            {
                speed = 12f;
            }
        }
    
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * grafity);
        }

        velocity.y += grafity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
