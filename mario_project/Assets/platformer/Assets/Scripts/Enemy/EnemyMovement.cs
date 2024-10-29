using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 4;
    public static bool DownedAllb = DownedEnemy.DownedAll;
    public static bool GoFasterAllb = DownedEnemy.GoFasterAll;
    public static bool Downed = false;
    public static bool GoFaster = false;
    Rigidbody2D rb2d_enemy;
    bool isFacingRight = false; // Start facing left
    Animator animator; // Reference to the Animator component

    IEnumerator Down()
    {
        // Set the "Downed" animation to true
        Downed = true;
        
        yield return new WaitForSeconds(1f);
        
        
    }
    IEnumerator Up()
    {
        yield return new WaitForSeconds(3f);
        // Set the "Downed" animation to false
        Downed = false;
        
        GoFaster = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d_enemy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float moveInput = moveSpeed;
       

        rb2d_enemy.velocity = new Vector2(moveSpeed, rb2d_enemy.velocity.y);
        if (rb2d_enemy.velocity.y > 0 )
        {
           StartCoroutine(Down());
           StartCoroutine(Up());
        }
        
        // Flip character based on movement direction
        //if (moveInput > 0 && !isFacingRight)
        //{
            //FlipCharacter(); // Face right
        //}
        //else if (moveInput < 0 && isFacingRight)
        //{
            ///FlipCharacter(); // Face left
        //}
        if (DownedAllb || Downed)
        {
            moveSpeed = 0;
            GetComponent<Animator>().SetBool("Downed", true);
            
            

        }
        else if (GoFasterAllb || GoFaster)
        {
            GetComponent<Animator>().SetBool("Downed", false);
            GetComponent<Animator>().SetBool("Faster", true);
            moveSpeed = 5;
            
        } else if(!DownedAllb)
        {
           moveSpeed = 3; 
        }
        
    }
    public void Down2()
    {
        StartCoroutine(Down());
        StartCoroutine(Up());
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
