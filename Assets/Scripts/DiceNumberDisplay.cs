using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceNumberDisplay : MonoBehaviour
{
    public TextMeshPro textMesh;
    [HideInInspector] public int maxRoll = 20; // Set from spawner

    private void Start()
    {
        int result = Random.Range(1, maxRoll + 1);
        textMesh.text = result.ToString();
        Destroy(gameObject, 6f);
    }
}
