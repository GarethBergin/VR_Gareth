using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SingleObjectSocket : MonoBehaviour
{
    public string requiredTag; // The tag the correct object must have
    public bool isObjectInSocket = false;

    private XRSocketInteractor socketInteractor;
    private MultiSocketManager manager;

    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        manager = FindObjectOfType<MultiSocketManager>();

        if (socketInteractor == null)
        {
            Debug.LogError($"No XRSocketInteractor found on {gameObject.name}!");
        }
        else
        {
            Debug.Log($"XRSocketInteractor found on {gameObject.name}");
            socketInteractor.selectEntered.AddListener(OnObjectPlaced);
            socketInteractor.selectExited.AddListener(OnObjectRemoved);
        }
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        var placedObject = args.interactableObject.transform.gameObject;

        Debug.Log($"An object entered {gameObject.name}: {placedObject.name}");

        // Check if the placed object has the required tag
        if (placedObject.CompareTag(requiredTag))
        {
            isObjectInSocket = true;
            Debug.Log($"{placedObject.name} successfully placed in {gameObject.name}");
            manager.CheckAllSockets(); // Notify manager to check progress
        }
        else
        {
            Debug.LogWarning($"{placedObject.name} does not match the required tag for {gameObject.name}!");
        }
    }

    private void OnObjectRemoved(SelectExitEventArgs args)
    {
        var removedObject = args.interactableObject.transform.gameObject;

        if (removedObject.CompareTag(requiredTag))
        {
            isObjectInSocket = false;
            Debug.Log($"{removedObject.name} was removed from {gameObject.name}");
        }
    }
}
