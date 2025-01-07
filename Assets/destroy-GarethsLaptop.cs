using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class destroy : MonoBehaviour
{

  // Set the tag to look for in the Inspector
    public string tagToDestroy = "burger"; // Example tag
    public AudioSource socketAudioSource;
    public AudioClip soundEffect;

    // This method will be called when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has the specific tag
        if (other.CompareTag(tagToDestroy))
        {
            // Destroy the object
            Destroy(other.gameObject);
            socketAudioSource.PlayOneShot(soundEffect);
        }
    }

    
}
