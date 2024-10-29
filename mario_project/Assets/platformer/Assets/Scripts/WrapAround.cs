using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RightCollider")
            transform.position = new Vector3(-8.7f, transform.position.y, transform.position.z);
        if (other.gameObject.tag == "LeftCollider")
            transform.position = new Vector3(8.5f, transform.position.y, transform.position.z);

    }
}
