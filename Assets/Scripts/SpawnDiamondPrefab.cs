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

    private DiceType diceType; // Reference to the dice's type

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
        if (_rigidbody.velocity.magnitude < stillThreshold)
        {
            stillTimer += Time.deltaTime;

            if (stillTimer >= stillTimeRequired && !hasStopped)
            {
                hasStopped = true;
                SpawnNumberDisplay();
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

        // Pass maxRoll to the display script
        DiceNumberDisplay displayScript = display.GetComponent<DiceNumberDisplay>();
        if (displayScript != null)
        {
            displayScript.maxRoll = diceType.maxRoll;
        }
        else
        {
            Debug.LogWarning("DiceNumberDisplay script missing on number prefab!");
        }
    }
}