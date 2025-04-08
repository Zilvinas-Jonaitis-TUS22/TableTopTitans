using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [Header("Objects To Spawn")]
    public GameObject malePrefab;
    public GameObject femalePrefab;
    public GameObject enemyPrefab;
    public GameObject treePrefab;
    public GameObject rockPrefab;

    [Header("Dice To Spawn")]
    public GameObject D4Prefab;
    public GameObject D6Prefab;
    public GameObject D8Prefab;
    public GameObject D10Prefab;
    public GameObject D12Prefab;
    public GameObject D20Prefab;

    [Header("Spawn Area")]
    public GameObject spawnArea;
    private BoxCollider spawnAreaCollider;

    private GameObject currentSpawnedObject;

    void Start()
    {
        spawnAreaCollider = spawnArea.GetComponent<BoxCollider>();
    }

    private void SpawnObjectAtPosition(GameObject prefab)
    {
        // Check if there is a current object, and if it needs to be replaced (only if it's in the spawn area)
        if (currentSpawnedObject != null && !IsObjectWithinSpawnArea(currentSpawnedObject))
        {
            // It's outside the spawn area, so don't destroy it, but you could choose to do so if needed
            Debug.Log("Object is outside the spawn area, not destroyed.");
        }
        else if (currentSpawnedObject != null)
        {
            // Only destroy the current object if it's within the spawn area
            Destroy(currentSpawnedObject);
        }

        // Proceed with spawning a new object
        Bounds bounds = spawnAreaCollider.bounds;
        Vector3 spawnPosition = GetSpawnPositionAbove(bounds, prefab);

        currentSpawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);

        // If the object has a Rigidbody, disable gravity for a brief moment to avoid physics errors
        Rigidbody rb = currentSpawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            StartCoroutine(EnableGravityAfterDelay(rb, 0.1f));
        }
    }

    private bool IsObjectWithinSpawnArea(GameObject obj)
    {
        Bounds areaBounds = spawnAreaCollider.bounds;
        return areaBounds.Contains(obj.transform.position); // Check if the object's position is within the spawn area
    }

    private Vector3 GetSpawnPositionAbove(Bounds bounds, GameObject prefab)
    {
        Collider prefabCollider = prefab.GetComponent<Collider>();
        float objectHeight = prefabCollider ? prefabCollider.bounds.size.y : 1f; // Default height if no collider

        float xPos = bounds.center.x;
        float zPos = bounds.center.z;
        float yPos = bounds.max.y + (objectHeight / 2); // Ensure object spawns just above

        // Use a raycast to find the exact top of the spawn area
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(xPos, bounds.max.y + 1f, zPos), Vector3.down, out hit, 5f))
        {
            yPos = hit.point.y + (objectHeight / 2); // Adjust spawn height
        }

        return new Vector3(xPos, yPos, zPos);
    }

    private IEnumerator EnableGravityAfterDelay(Rigidbody rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    public void SpawnMale() => SpawnObjectAtPosition(malePrefab);
    public void SpawnFemale() => SpawnObjectAtPosition(femalePrefab);
    public void SpawnEnemy() => SpawnObjectAtPosition(enemyPrefab);
    public void SpawnTree() => SpawnObjectAtPosition(treePrefab);
    public void SpawnRock() => SpawnObjectAtPosition(rockPrefab);
    public void SpawnD4() => SpawnObjectAtPosition(D4Prefab);
    public void SpawnD6() => SpawnObjectAtPosition(D6Prefab);
    public void SpawnD8() => SpawnObjectAtPosition(D8Prefab);
    public void SpawnD10() => SpawnObjectAtPosition(D10Prefab);
    public void SpawnD12() => SpawnObjectAtPosition(D12Prefab);
    public void SpawnD20() => SpawnObjectAtPosition(D20Prefab);
}
