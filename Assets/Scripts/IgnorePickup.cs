using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePickup : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
            return;
    }

}
