using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSocketManager : MonoBehaviour
{
    public SingleObjectSocket[] sockets; // List of all socket scripts
    public int counter = 0; // Counter for completed sets

    public void Start(){

    }
    public void CheckAllSockets()
    {
        foreach (var socket in sockets)
        {
            if (!socket.isObjectInSocket) // If any socket is missing its object
            {
                return; // Exit without incrementing the counter
            }
        }

        // If all sockets are filled
        counter++;
        Debug.Log("All objects are in their sockets! Counter: " + counter);

        // Optionally reset the sockets for reuse
        foreach (var socket in sockets)
        {
            socket.isObjectInSocket = false;
        }
    }
}
