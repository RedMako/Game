using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLeft : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
{
    // Check if the character enters the DownLeftPortal
    if (other.CompareTag("DownLeftPortal"))
    {
        // Teleport to UpperRightPortal
        TeleportToUpperRight();
    }
}

private void TeleportToUpperRight()
{
    // Set the position to UpperRightPortal's position
    Vector3 upperRightPosition = new Vector3(10.03918f, 4.869597f, 0); 
    transform.position = upperRightPosition;
}
}
