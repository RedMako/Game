using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public float bounceHeight = 0.5f; // How high the block bounces
    public float bounceDuration = 0.2f; // Duration of the bounce
    private Vector3 originalPosition;
    private static bool isBouncing = false; // Prevent multiple bounces at once

    private void Start()
    {
        originalPosition = transform.position; // Store the original position of the block
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is hitting the block
        if (collision.gameObject.CompareTag("Player") && !isBouncing)
        {
            // Check if the collision point is below the block
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.point.y < transform.position.y)
                {
                    // If there is an enemy above the block, call Down2 on the enemy
                    if (EnemyTriggerBlock.EnemyAbove && EnemyTriggerBlock.Death != null)
                    {
                        EnemyTriggerBlock.Death.Down2();
                    }

                    // Start the bounce coroutine
                    StartCoroutine(Bounce());
                    break; // Exit the loop after the first valid hit
                }
            }
        }
    }

    private IEnumerator Bounce()
    {
        isBouncing = true; // Mark that the block is currently bouncing

        // Move up
        Vector3 targetPosition = originalPosition + Vector3.up * bounceHeight;
        float elapsedTime = 0f;

        while (elapsedTime < bounceDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / bounceDuration));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        // Move down
        elapsedTime = 0f;
        while (elapsedTime < bounceDuration)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, (elapsedTime / bounceDuration));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        transform.position = originalPosition; // Ensure it ends at the original position
        isBouncing = false; // Allow the block to bounce again
    }
}