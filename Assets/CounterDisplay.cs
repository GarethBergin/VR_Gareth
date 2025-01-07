using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class CounterDisplay : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Reference to the TextMeshPro component
    public MultiSocketManager counterScript; // Reference to your existing script

    private void Update()
    {
        if (counterScript != null && counterText != null)
        {
            // Update the UI text with the counter value from the other script
            counterText.text = "Counter: " + counterScript.counter.ToString();
        }
    }
}

