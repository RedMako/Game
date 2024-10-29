using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckCollisionPow : MonoBehaviour
{
     public static bool pow1 = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PowTrigger1.canPow1)
            {
            GetComponent<BoxCollider2D>().enabled = false;
            pow1 = true;
            }
        }
        
    }
}
