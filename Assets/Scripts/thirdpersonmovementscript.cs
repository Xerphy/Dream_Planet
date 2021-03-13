using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersonmovementscript : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;

    public float speed = 6f;    // Speed of character movement
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  // Checks if the invisible sphere below the player collides with the ground

        if (isGrounded && velocity.y < 0)
        {
            //controller.slopeLimit = 45.0f; // Added to stop clipping on 90 degree walls
            velocity.y = -2f;
        }

        /*
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)    // Detects if the player jumps into an object and bumps their head on something
        {
            velocity.y = -2f;
        }
        */

        float horizontal = Input.GetAxisRaw("Horizontal");  // Captures W, S, Up Arrow, and Down Arrow key inputs
        float vertical = Input.GetAxisRaw("Vertical");  // Captures A, D, Left Arrow, and Right Arrow key inputs
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //controller.slopeLimit = 90.0f; // Added to stop clipping on 90 degree walls
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);  // Moves the character based on gravity
    }
}
