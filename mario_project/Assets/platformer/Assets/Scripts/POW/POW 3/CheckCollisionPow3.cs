using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckCollisionPow3 : MonoBehaviour
{
     public static bool pow3 = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PowTrigger3.canPow3)
            {
            GetComponent<BoxCollider2D>().enabled = false;
            pow3 = true;
            }
        }
        
    }
}
