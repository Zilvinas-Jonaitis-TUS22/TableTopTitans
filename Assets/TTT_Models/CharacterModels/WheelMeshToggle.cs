using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMeshToggle : MonoBehaviour
{
    public GameObject FigurineA; // First mesh
    public GameObject FigurineB; // Second mesh

    private float rotationThreshold = 45f; // Threshold for toggling mesh based on rotation (in degrees)
    private float currentRotation = 0f; // Current rotation value of the wheel
    private bool isFigurineAActive = true; // Track which mesh is currently active

    private void Start()
    {
        // Initially, set mesh1 active and mesh2 inactive
        FigurineA.SetActive(true);
        FigurineB.SetActive(false);
    }

    private void Update()
    {
        // Get the input from the XR controller (Meta XR SDK)
        float rotationInput = GetWheelRotationInput();

        // Update the current rotation based on input
        currentRotation += rotationInput * Time.deltaTime;

        // Check if rotation exceeds the threshold to toggle meshes
        if (Mathf.Abs(currentRotation) >= rotationThreshold)
        {
            ToggleMesh();
            currentRotation = 0f; // Reset the rotation after toggling
        }
    }

    private float GetWheelRotationInput()
    {
        // Example: Use the XR controller's input axis or other input to detect rotation
        // Assuming that the XR device provides a rotation value (adjust as needed for your input setup)

        // Return the horizontal axis (adjust if your controller input is different)
        return Input.GetAxis("Horizontal"); // This could be different depending on your XR setup
    }

    private void ToggleMesh()
    {
        // Toggle the active mesh
        isFigurineAActive = !isFigurineAActive;

        // Activate the new mesh and deactivate the old one
        FigurineA.SetActive(isFigurineAActive);
        FigurineB.SetActive(!isFigurineAActive);
    }
}
