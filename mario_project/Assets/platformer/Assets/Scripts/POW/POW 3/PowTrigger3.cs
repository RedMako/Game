using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowTrigger3 : MonoBehaviour
{
    public static bool canPow3 = false;
    public GameObject TileMap;
    IEnumerator AnimationDelay3()
    {
        
        // Set the "Powed" animation to true
        Debug.Log(TileMap.GetComponent<Animator>().GetBool("Powed"));
        TileMap.GetComponent<Animator>().SetBool("Powed", true);
        Debug.Log(TileMap.GetComponent<Animator>().GetBool("Powed"));
        yield return new WaitForSeconds(0.9f);
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
    IEnumerator enablepow3()
    {
        yield return new WaitForSeconds(0.5f);
        canPow3 = true;
    }
   
    Rigidbody2D rb2d_pow;
    void Start()
    {
        Debug.Log("Starting 3rd pow");
        rb2d_pow = GetComponent<Rigidbody2D>();
        StartCoroutine(enablepow3());
        
    }
    void FixedUpdate()
    {
        
        if (CheckCollisionPow3.pow3)
        {
            
            if (canPow3)
            {
            CheckCollisionPow3.pow3 = false;
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(AnimationDelay3());
            FindObjectOfType<DownedEnemy>().Downed();
            StartCoroutine(DisableColliderAfterDelay());
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 1f);
            } else {
                CheckCollisionPow3.pow3 = false;
            }
        }

    }
}
