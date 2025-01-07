using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketInteraction : MonoBehaviour
{
    public AudioSource socketAudioSource;
    public AudioClip soundEffect;
    public GameObject newPrefab; // The prefab to instantiate
    public float delay = 2.0f;   // Time in seconds before replacing the object
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable")) // Ensure the object has the correct tag
        {
            StartCoroutine(ReplaceObject(other.gameObject));
            socketAudioSource.PlayOneShot(soundEffect);
        }
        else if (other.CompareTag("burger")) // Ensure the object has the correct tag
        {
            Debug.Log("destroy");
        }
    }

    private System.Collections.IEnumerator ReplaceObject(GameObject currentObject)
    {
        yield return new WaitForSeconds(delay);

        // Instantiate the new prefab at the same position and rotation as the current object
        Instantiate(newPrefab, currentObject.transform.position, currentObject.transform.rotation);

        // Destroy the old object
        Destroy(currentObject);
    }

    
}
