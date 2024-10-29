using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesLeft : MonoBehaviour
{
    public float moveSpeed = 4;
    Rigidbody2D rb2d_enemy;
    bool isFacingRight = true; // Start facing right
    Animator animator; // Reference to the Animator component

    // Start is called before the first frame update
    void Start()
    {
        rb2d_enemy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move to the left by setting velocity to a negative value
        rb2d_enemy.velocity = new Vector2(-moveSpeed, rb2d_enemy.velocity.y); // Move left

        

        if (DownedEnemy.DownedAll)
        {
            moveSpeed = 0;
            GetComponent<Animator>().SetBool("Downed", true);
        }
        else if (DownedEnemy.GoFasterAll)
        {
            GetComponent<Animator>().SetBool("Downed", false);
            GetComponent<Animator>().SetBool("Faster", true);
            moveSpeed = 5;
        }
        else if (!DownedEnemy.DownedAll)
        {
            moveSpeed = 3; 
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