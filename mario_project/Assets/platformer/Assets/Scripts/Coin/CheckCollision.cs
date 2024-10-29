using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public static bool collect = false;
    public static bool enemy = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collect = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (enemy){
                enemy = false;
            } else {
                enemy = true;
            }
        }
    }
}
