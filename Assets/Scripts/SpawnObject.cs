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
            // If the object is inside the spawn area, destroy it
            if (IsObjectInSpawnArea(currentSpawnedObject))
            {
                Destroy(currentSpawnedObject);
            }
        }


        Vector3 spawnCenter = spawnAreaCollider.transform.position + spawnAreaCollider.center;
        Vector3 spawnSize = spawnAreaCollider.size;
        float xPos = Random.Range(spawnCenter.x - spawnSize.x / 2, spawnCenter.x + spawnSize.x / 2);
        float yPos = Random.Range(spawnCenter.y - spawnSize.y / 2, spawnCenter.y + spawnSize.y / 2);
        float zPos = Random.Range(spawnCenter.z - spawnSize.z / 2, spawnCenter.z + spawnSize.z / 2);

        Vector3 spawnPosition = new Vector3(xPos, yPos, zPos);


        currentSpawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    private void Update()
    {

        // Check if the object is still in the spawn area, and destroy it if necessary
        if (currentSpawnedObject != null && IsObjectInSpawnArea(currentSpawnedObject))
        {
            // If the current object is inside the spawn area, we don't need to destroy it yet
            return;
        }

        // If the object is outside the spawn area, allow for the next object to be spawned
        if (currentSpawnedObject != null && !IsObjectInSpawnArea(currentSpawnedObject))
        {
            currentSpawnedObject = null; // Object is outside the spawn area, so reset
        }
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
