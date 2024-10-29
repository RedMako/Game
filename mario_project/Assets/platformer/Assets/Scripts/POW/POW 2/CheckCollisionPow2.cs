using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckCollisionPow2 : MonoBehaviour
{
     public static bool pow2 = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PowTrigger2.canPow2)
            {
            GetComponent<BoxCollider2D>().enabled = false;
            pow2 = true;
            }
        }
        
    }
}
