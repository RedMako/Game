using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour
{

    void Start()
    {
        // Ensure the BoxCollider2D is not set to trigger
        GetComponent<BoxCollider2D>().isTrigger = false;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            if (DownedEnemy.DownedAll)
            {
                // Destroy the object
                Destroy(gameObject);
            }else if(EnemyMovement.DownedAllb || EnemyMovement.Downed)
            {
                // Destroy the  object
                Destroy(gameObject);


            }
            else
            {
                // Destroy the player object
                Destroy(collision.gameObject);
            }
            
            
        }
    }
}
