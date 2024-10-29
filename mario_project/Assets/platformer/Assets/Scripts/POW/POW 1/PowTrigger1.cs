using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowTrigger1 : MonoBehaviour
{
    public static bool canPow1 = false;
    public GameObject TileMap;
    private Rigidbody2D rb2d_pow;

    IEnumerator DisableColliderAfterDelay()
    {
        // Wait for 1.2 seconds
        yield return new WaitForSeconds(1.2f);

        // Disable the BoxCollider2D component
        GetComponent<BoxCollider2D>().enabled = false;
    }
    IEnumerator enablepow()
    {
        yield return new WaitForSeconds(0.7f);
        canPow1 = true;
    }


    IEnumerator AnimationDelay()
    {
        Debug.Log(TileMap.GetComponent<Animator>().GetBool("Powed"));
         TileMap.GetComponent<Animator>().SetBool("Powed", true);
         Debug.Log(TileMap.GetComponent<Animator>().GetBool("Powed"));
        yield return new WaitForSeconds(1f);
        // Set the "Powed" animation to false
        TileMap.GetComponent<Animator>().SetBool("Powed", false);
        Debug.Log(TileMap.GetComponent<Animator>().GetBool("Powed"));
    }

    void Start()
    {
        Debug.Log("Starting 1st pow");
        rb2d_pow = GetComponent<Rigidbody2D>();
        StartCoroutine(enablepow());
    }

    void FixedUpdate()
    {
        if (CheckCollisionPow.pow1)
        {
            
            if (canPow1)
            {
                CheckCollisionPow.pow1 = false;
                GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(AnimationDelay());
                FindObjectOfType<DownedEnemy>().Downed();
                StartCoroutine(DisableColliderAfterDelay());
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                CheckCollisionPow.pow1 = false;
            }
            
            
        }
    }
}
