using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 5;
    private Rigidbody2D rb2d;
    private bool isFacingRight = false; // Start facing left
    private Animator animator; // Reference to the Animator component
    private bool isJumping = false; // Flag to track if the character is jumping

    public bool betterJump = false;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    // Audio settings
    public AudioSource runningSound; // Reference to the Audio Source for running sound
    private bool isRunning = false; // Flag to track if the character is running
    public float skipTime = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveInput = 0;

        // Check input for horizontal movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -moveSpeed; // Set move input for left movement
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = moveSpeed; // Set move input for right movement
        }

        // Update the velocity
        rb2d.velocity = new Vector2(moveInput, rb2d.velocity.y);

        // Flip character based on movement direction
        if (moveInput > 0 && !isFacingRight)
        {
            FlipCharacter(); // Face right
        }
        else if (moveInput < 0 && isFacingRight)
        {
            FlipCharacter(); // Face left
        }

        // Control the animation based on the movement state
        animator.SetBool("IsMoving", moveInput != 0);

        // Handle jumping
        if (Input.GetKey(KeyCode.Space) && CheckGround.isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isJumping = true; // Set the jumping flag to true
        }
        else if (!CheckGround.isGrounded && rb2d.velocity.y < 0)
        {
            isJumping = false; // Set the jumping flag to false when falling
        }

        // Control the jumping animation
        animator.SetBool("IsJumping", isJumping);
        
        // Better jump control
        if (betterJump)
        {
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        // Play running sound if moving and not jumping
        if (moveInput != 0 && CheckGround.isGrounded) // Check if the character is grounded
        {
            if (!isRunning)
            {
                runningSound.time = skipTime;
                runningSound.Play(); // Play sound when starting to run
                isRunning = true; // Set running flag to true
            }
        }
        else
        {
            if (isRunning)
            {
                runningSound.Stop(); // Stop sound when not running
                isRunning = false; // Set running flag to false
            }
        }
    }

    // Method to flip the character's sprite
    void FlipCharacter()
    {
        isFacingRight = !isFacingRight; // Toggle the facing direction
        Vector3 scaler = transform.localScale; // Get current scale
        scaler.x *= -1; // Flip the x scale
        transform.localScale = scaler; // Apply the new scale
    }
}