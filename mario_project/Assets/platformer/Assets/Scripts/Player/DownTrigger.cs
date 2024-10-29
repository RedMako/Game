using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTrigger : MonoBehaviour
{
    private bool canDown = false; // Control if the trigger can down enemies
    public float downDuration = 5f; // Duration for which enemies remain downed

    private void Start()
    {
        StartCoroutine(EnableDown()); // Start the coroutine to enable downing
    }

    private IEnumerator EnableDown()
    {
        yield return new WaitForSeconds(0.2f);
        canDown = true; // Allow downing of enemies
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider belongs to an enemy
        if (collision.CompareTag("Enemy") && canDown)
        {
            // Get the DownedEnemy component from the enemy GameObject
            DownedEnemy downedEnemy = collision.GetComponent<DownedEnemy>();
            if (downedEnemy != null)
            {
                downedEnemy.Downed(); // Call the Downed method to down the enemy
                StartCoroutine(DisableColliderAfterDelay()); // Disable collider after downing
            }
        }
    }

    private IEnumerator DisableColliderAfterDelay()
    {
        // Wait for the down duration
        yield return new WaitForSeconds(downDuration);
        // Disable the BoxCollider2D component
        GetComponent<BoxCollider2D>().enabled = false;
    }
}