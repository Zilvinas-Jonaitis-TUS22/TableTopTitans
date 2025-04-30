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

    private float gracePeriod = 1.0f; // Time in seconds to ignore rolling logic after spawn
    private float timeSinceSpawn = 0f;

    private DiceType diceType;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        diceType = GetComponent<DiceType>();

        if (diceType == null)
        {
            Debug.LogWarning("DiceType component is missing on this dice!");
        }
        timeSinceSpawn = 0f;
    }

    private void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        // Ignore logic until grace period has passed
        if (timeSinceSpawn < gracePeriod) return;

        float currentSpeed = _rigidbody.velocity.magnitude;

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
                    SpawnNumberDisplay();
                }

                highestSpeed = 0f;
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

        Destroy(display, 10f); // Automatically destroy after 10 seconds
    }
}
