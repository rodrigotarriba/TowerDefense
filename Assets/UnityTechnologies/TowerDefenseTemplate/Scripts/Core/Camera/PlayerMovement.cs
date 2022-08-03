using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main class for FPS player movement 
/// </summary>

//rtcNote this class pertains only to FPS - should be addressed appropiately

public class PlayerMovement : MonoBehaviour
{
    private float xMovement;
    private float zMovement;

    public CharacterController controller;

    public float movementSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private Vector3 fallingVelocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, 1 << 16);

        if(isGrounded && fallingVelocity.y < 0)
        {
            fallingVelocity.y = -2f;
        }

        //Guard clause, player only moves when in the ground
        
        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");


        //Motion player is to move based on its orientation
        Vector3 motionDirection = (transform.right * xMovement) + (transform.forward * zMovement);

        //Move character controller based on new direction
        controller.Move(motionDirection * movementSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            fallingVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        fallingVelocity.y += gravity * Time.deltaTime;

        controller.Move(fallingVelocity * Time.deltaTime);


    }
}
