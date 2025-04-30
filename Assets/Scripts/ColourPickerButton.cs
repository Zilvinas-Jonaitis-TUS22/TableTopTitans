using UnityEngine;

public class ColourPickerButton : MonoBehaviour
{
    public static Color currentColor; // Static to store the current color across the scene

    // Define the updated color cycle (white, black, grey, red, orange, yellow, green, blue, pink, purple)
    private Color[] colors = {
        Color.black,            // Black
        Color.white,            // White
        Color.grey,             // Grey
        Color.red,              // Red
        new Color(1f, 0.647f, 0f), // Orange (custom color)
        Color.yellow,           // Yellow
        Color.green,            // Green
        Color.blue,             // Blue
        new Color(1f, 0.078f, 0.576f), // Pink (custom color)
        new Color(0.5f, 0f, 0.5f)  // Purple (custom color)
    };
    private int currentColorIndex = 0;  // To keep track of the current color

    // Call this function to cycle to the next color
    public void ChangeColor()
    {
        // Update the color index to the next color in the cycle
        currentColorIndex++;

        // If the current color index exceeds the available colors, reset it to 0 (white)
        if (currentColorIndex >= colors.Length)
        {
            currentColorIndex = 0;
        }

        // Get the next color from the array
        currentColor = colors[currentColorIndex];

        Debug.Log("Changed to color: " + currentColor);

        // Find all dice in the scene and apply the new color
        DiceColour[] allDice = FindObjectsOfType<DiceColour>();

        foreach (DiceColour dice in allDice)
        {
            // Change the color of each dice object found
            dice.ChangeColor(currentColor);
        }
    }
}
