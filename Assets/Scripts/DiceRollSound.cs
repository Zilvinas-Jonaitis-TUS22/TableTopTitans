using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceRollSound : MonoBehaviour
{
    private Grabbable grabbable;
    private Rigidbody rb;
    private AudioSource rollAudio;
    private bool hasBeenReleased = false;

    private void Awake()
    {
        grabbable = GetComponent<Grabbable>();
        rb = GetComponent<Rigidbody>();
        rollAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        // Check if the Grabbable component can handle selection events, such as when grabbed or released.
        // If there's no specific event, we will check for velocity changes in Update().
    }

    private void OnDisable()
    {
        // We can clean up any event listeners or references here if necessary, but we don't have events yet.
    }

    private void Update()
    {
        // Check if the Grabbable component is selected or not (i.e., it is grabbed or released)
        if (grabbable.isSelected)
        {
            // The object is being held, so no need to play the rolling sound
            hasBeenReleased = false;
        }
        else if (!grabbable.isSelected && !hasBeenReleased)
        {
            // The object is released, check if it's moving
            if (rb.velocity.magnitude > 0.1f && !rollAudio.isPlaying)
            {
                // Play the sound if it's rolling and not already playing
                rollAudio.Play();
                hasBeenReleased = true; // Ensure it only triggers once after being released
            }
        }
    }
}
