using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnDiamondPrefab : MonoBehaviour
{
    public GameObject numberPrefab; // Assign your TMP number prefab here
    private Rigidbody _rigidbody;

    private float stillThreshold = 0.05f;
    private float stillTimeRequired = 1.0f;
    private float stillTimer = 0f;

    private float minRollSpeed = 4f; // Minimum speed to consider it a valid roll
    private float highestSpeed = 0f;

    private DiceType diceType;
    private bool hasStopped = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        diceType = GetComponent<DiceType>();

        if (numberPrefab == null)
        {
            Debug.LogError("Number Prefab is NOT assigned!");
        }

        if (diceType == null)
        {
            Debug.LogWarning("DiceType component is missing on this dice!");
        }
    }

    private void Update()
    {
        float currentSpeed = _rigidbody.velocity.magnitude;

        // Track the highest speed
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

                if (highestSpeed >= minRollSpeed)
                {
                    Debug.Log("Spawning number display");
                    SpawnNumberDisplay();
                }

                highestSpeed = 0f; // Reset speed
            }
        }
        else
        {
            // Dice is still moving — reset
            stillTimer = 0f;
            hasStopped = false;
        }
    }

    private void SpawnNumberDisplay()
    {
        if (diceType == null || numberPrefab == null) return;

        Vector3 spawnPos = transform.position + Vector3.up * 0.5f; // Adjust height
        Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f); // Face upward

        GameObject display = Instantiate(numberPrefab, spawnPos, rotation, transform);
        display.transform.localScale = new Vector3(-0.5f, 0.8f, 0.8f);

        DiceNumberDisplay displayScript = display.GetComponent<DiceNumberDisplay>();
        if (displayScript != null)
        {
            displayScript.maxRoll = diceType.maxRoll;
        }
        else
        {
            Debug.LogWarning("DiceNumberDisplay script missing on number prefab!");
        }

        Destroy(display, 10f);
    }
}
