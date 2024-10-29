using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinCollection : MonoBehaviour
{   
    public float moveSpeed = 5;
    Animator animator_coin; 
    Rigidbody2D rb2d_coin;
    void Start()
    {
        rb2d_coin = GetComponent<Rigidbody2D>();
        animator_coin = GetComponent<Animator>(); // Get the Animator component
    }
    void FixedUpdate()
    {
        if (CheckCollision.enemy){
            rb2d_coin.velocity = new Vector2(-moveSpeed, rb2d_coin.velocity.y);
        } else {
            rb2d_coin.velocity = new Vector2(moveSpeed, rb2d_coin.velocity.y);
        }
        if (CheckCollision.collect)
        {
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
        }

    }
}
