using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spawnArea;
    private BoxCollider spawnAreaCollider;
    void Start()
    {
        spawnAreaCollider = GetComponent<BoxCollider>();

    }


    public void SpawnCube()
    {
        Vector3 spawnCenter = spawnAreaCollider.transform.position + spawnAreaCollider.center;
        Vector3 spawnSize = spawnAreaCollider.size;
        float xPos = Random.Range(spawnCenter.x - spawnSize.x / 2, spawnCenter.x + spawnSize.x / 2);
        float yPos = Random.Range(spawnCenter.y - spawnSize.y / 2, spawnCenter.y + spawnSize.y / 2);
        float zPos = Random.Range(spawnCenter.z - spawnSize.z / 2, spawnCenter.z + spawnSize.z / 2);

        Vector3 spawnPosition = new Vector3(xPos, yPos, zPos);
        Instantiate(cubePrefab, spawnPosition, Quaternion.identity);

    }
}
