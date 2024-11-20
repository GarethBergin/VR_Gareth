using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class destroy : MonoBehaviour
{
    private void Start(){
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a specific tag
        if (collision.gameObject.CompareTag("Target"))
        {
            // Destroy this object
            Destroy(gameObject);

            // Optionally, destroy the other object
            // Destroy(collision.gameObject);
        }
    }
}
