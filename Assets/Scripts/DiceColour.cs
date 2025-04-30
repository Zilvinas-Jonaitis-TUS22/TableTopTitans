using UnityEngine;

public class DiceColour : MonoBehaviour
{
    // Reference to the Renderer of the dice (this will be on a child object)
    private Renderer diceRenderer;

    private void Awake()
    {
        // Try to get the Renderer component from the child object (using GetComponentInChildren)
        diceRenderer = GetComponentInChildren<Renderer>();

        // Apply the color to the dice immediately on start (or you can wait for the color change)
        if (diceRenderer != null)
        {
            // Set the color to the current color from ColourPickerButton
            diceRenderer.material.color = ColourPickerButton.currentColor; // Get color from the static variable
        }
        else
        {
            Debug.LogError("Renderer component not found on the dice or its child object!");
        }
    }

    // Method to change color dynamically when called
    public void ChangeColor(Color newColor)
    {
        if (diceRenderer != null)
        {
            diceRenderer.material.color = newColor;
            Debug.Log("Color changed to: " + newColor);  // Log to ensure color is being applied
        }
        else
        {
            Debug.LogError("Renderer component is missing from dice or its child!");
        }
    }
}
