using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [Header ("Objects To Spawn")]
    public GameObject malePrefab;
    public GameObject femalePrefab;
    public GameObject enemyPrefab;
    public GameObject treePrefab;
    public GameObject rockPrefab;

    [Header ("Dice To Spawn")]
    public GameObject D4Prefab;
    public GameObject D6Prefab;
    public GameObject D8Prefab;
    public GameObject D10Prefab;
    public GameObject D12Prefab;
    public GameObject D20Prefab;

    [Header ("Spawn Area")]
    public GameObject spawnArea;
    private BoxCollider spawnAreaCollider;

    private GameObject currentSpawnedObject;

   
    void Start()
    {
   spawnAreaCollider = spawnArea.GetComponent<BoxCollider>();

    }

    private void SpawnObjectAtPosition(GameObject prefab)
    {
        if (currentSpawnedObject != null)
        {
            Destroy(currentSpawnedObject);
        }

        Bounds bounds = spawnAreaCollider.bounds;
        Vector3 spawnPosition = GetCenteredSpawnPosition(bounds, prefab);

        currentSpawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetCenteredSpawnPosition(Bounds bounds, GameObject prefab)
    {
        Collider prefabCollider = prefab.GetComponent<Collider>();
        float objectHeight = prefabCollider ? prefabCollider.bounds.size.y : 1f; // Default height if no collider

        float xPos = bounds.center.x;
        float zPos = bounds.center.z;
        float yPos = bounds.center.y + (bounds.extents.y) + (objectHeight / 2); // Spawn just above the middle

        return new Vector3(xPos, yPos, zPos);
    }

    private bool IsObjectInSpawnArea(GameObject obj)
    {
        Collider objectCollider = obj.GetComponent<Collider>();
        if (objectCollider != null && spawnAreaCollider.bounds.Intersects(objectCollider.bounds))
        {
            return true;
        }
        return false;
    }

    public void SpawnMale()
    {
        SpawnObjectAtPosition(malePrefab);
    }

    public void SpawnFemale()
    {
        SpawnObjectAtPosition(femalePrefab);
    }

    public void SpawnEnemy()
    {
        SpawnObjectAtPosition(enemyPrefab);
    }

    public void SpawnTree()
    {
        SpawnObjectAtPosition(treePrefab);
    }

    public void SpawnRock()
    {
        SpawnObjectAtPosition(rockPrefab);
    }

    public void SpawnD4()
    {
        SpawnObjectAtPosition(D4Prefab);
    }

    public void SpawnD6()
    {
        SpawnObjectAtPosition(D6Prefab);
    }

    public void SpawnD8()
    {
        SpawnObjectAtPosition(D8Prefab);
    }

    public void SpawnD10()
    {
        SpawnObjectAtPosition(D10Prefab);

    }

    public void SpawnD12()
    {
        SpawnObjectAtPosition(D12Prefab);
    }

    public void SpawnD20()
    {
        SpawnObjectAtPosition(D20Prefab);
    }
}
