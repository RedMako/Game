using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the character enters the DownRightPortal
        if (other.CompareTag("DownRightPortal"))
        {
            // Teleport to UpperLeftPortal
            TeleportToUpperLeft();
        }
    }

    private void TeleportToUpperLeft()
    {
        // Set the position to UpperLeftPortal's position
        Vector3 upperLeftPosition = new Vector3(-7.620816f, 4.869597f, 0); 
        transform.position = upperLeftPosition;
    }
}
