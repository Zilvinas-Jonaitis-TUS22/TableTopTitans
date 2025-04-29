using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnDiamondPrefab : MonoBehaviour
{
    public GameObject numberPrefab; // Assign your TMP number prefab here
    private Rigidbody _rigidbody;
    private bool hasStopped = false;
    private float stillThreshold = 0.05f;
    private float stillTimeRequired = 1.0f;
    private float stillTimer = 0f;

    public float minRollSpeed = 30f; // Minimum speed to consider it a valid roll
    private float highestSpeed = 0f;

    private DiceType diceType;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        diceType = GetComponent<DiceType>();

        if (diceType == null)
        {
            Debug.LogWarning("DiceType component is missing on this dice!");
        }
    }

    private void Update()
    {
        float currentSpeed = _rigidbody.velocity.magnitude;

        // Track peak speed
        if (currentSpeed > highestSpeed)
        {
            highestSpeed = currentSpeed;
        }

        if (currentSpeed < stillThreshold)
        {
            stillTimer += Time.deltaTime;

            if (stillTimer >= stillTimeRequired && !hasStopped)
            {
                hasStopped = true;

                // Only spawn number if it was rolled hard enough
                if (highestSpeed >= minRollSpeed)
                {
                    SpawnNumberDisplay();
                }
            }
        }
        else
        {
            stillTimer = 0f;
            hasStopped = false;
        }
    }

    private void SpawnNumberDisplay()
    {
        if (diceType == null || numberPrefab == null) return;

        Vector3 spawnPos = transform.position + Vector3.up * 0.2f;
        Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f); // Face upward

        GameObject display = Instantiate(numberPrefab, spawnPos, rotation);

        DiceNumberDisplay displayScript = display.GetComponent<DiceNumberDisplay>();
        if (displayScript != null)
        {
            displayScript.maxRoll = diceType.maxRoll;
        }
        else
        {
            Debug.LogWarning("DiceNumberDisplay script missing on number prefab!");
        }

        Destroy(display, 10f); // Automatically destroy after 10 seconds
    }
}
