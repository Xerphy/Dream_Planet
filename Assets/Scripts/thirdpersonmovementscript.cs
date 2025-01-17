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
    bool canDoubleJump = false;//Check to make sure that player is allowed to double jump
    public float doubleJumpMultiplier = 0.5f;
    bool hasJetPack = false;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //checkpoint respawn coord
    public Vector3 respawnLocation;

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

        //XZ movement
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //Jumping
        if(isGrounded)
        {
            canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                //controller.slopeLimit = 90.0f; // Added to stop clipping on 90 degree walls
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else if(Input.GetButtonDown("Jump") && canDoubleJump && hasJetPack)//If player is in the air and can double jump and has jetpack upgrade, they will double jump
        {
            velocity.y = jumpHeight * doubleJumpMultiplier;
            canDoubleJump = false;
        }
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);  // Moves the character based on gravity
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Checkpoint")//if player reaches a checkpoint, then respawnLocation is set to the position of said checkpoint
        {
            respawnLocation = other.transform.position;
        }
        else if(other.tag == "DeathZone")
        {
            transform.position = respawnLocation;//teleport player to last checkpoint when they fall off level
        }
        else if(other.tag == "Jetpack")
        {
            hasJetPack = true;
        }
    }
}
