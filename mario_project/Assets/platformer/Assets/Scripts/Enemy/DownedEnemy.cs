using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DownedEnemy : MonoBehaviour
{ 
    public static bool DownedAll = false;
    public static bool GoFasterAll = false;
    IEnumerator Down()
    {
        // Set the "Downed" animation to true
        DownedAll = true;
        
        yield return new WaitForSeconds(5f);
        
        
    }
    IEnumerator Up()
    {
        yield return new WaitForSeconds(5f);
        // Set the "Downed" animation to false
        DownedAll = false;
        
        GoFasterAll = true;
    }
    public void Downed()
    {
        StartCoroutine(Down());
        StartCoroutine(Up());
    }



}
