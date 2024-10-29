using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerBlock : MonoBehaviour
{
    public static EnemyMovement Death;
    public static bool EnemyAbove = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyAbove = true;
            Death = other.GetComponent<EnemyMovement>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyAbove = false;
            Death = null; // Reset the reference when the enemy exits
        }
    }
}