using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PowTrigger2 : MonoBehaviour
{
    public static bool canPow2 = false;
    public GameObject TileMap;
    IEnumerator AnimationDelay2()
    {
        Debug.Log(TileMap.GetComponent<Animator>().GetBool("Powed"));
        
        // Set the "Powed" animation to true
        TileMap.GetComponent<Animator>().SetBool("Powed", true);
        Debug.Log(TileMap.GetComponent<Animator>().GetBool("Powed"));
        yield return new WaitForSeconds(1f);
        // Set the "Powed" animation to false
        TileMap.GetComponent<Animator>().SetBool("Powed", false);
        Debug.Log(TileMap.GetComponent<Animator>().GetBool("Powed"));
    }
   IEnumerator DisableColliderAfterDelay()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1.2f);

        // Disable the BoxCollider2D component
        GetComponent<BoxCollider2D>().enabled = false;
    }
   IEnumerator Enablepow2()
    {
        yield return new WaitForSeconds(1.2f);
        canPow2 = true;
    }
    Rigidbody2D rb2d_pow;
    void Start()
    {
        Debug.Log("Starting 2nd pow");
        rb2d_pow = GetComponent<Rigidbody2D>();
        StartCoroutine(Enablepow2());
        
    }
    void FixedUpdate()
    {
        
        if (CheckCollisionPow2.pow2)
        {
            
            if (canPow2)
            {
            CheckCollisionPow2.pow2 = false;
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(AnimationDelay2());
            FindObjectOfType<DownedEnemy>().Downed();
            StartCoroutine(DisableColliderAfterDelay());
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            } else {
                CheckCollisionPow2.pow2 = false;
            }
        }

    }
}
