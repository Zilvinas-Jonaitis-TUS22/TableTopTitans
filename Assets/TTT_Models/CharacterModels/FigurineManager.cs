using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurineManager : MonoBehaviour
{
    public string figurineTagA = "FigurineA";  // Set tag for first figurine
    public string figurineTagB = "FigurineB";  // Set tag for second figurine

    private GameObject figurineA;
    private GameObject figurineB;

    void Start()
    {
        // Find objects with assigned tags
        figurineA = GameObject.FindGameObjectWithTag(figurineTagA);
        figurineB = GameObject.FindGameObjectWithTag(figurineTagB);

        if (figurineA == null || figurineB == null)
        {
            Debug.LogError("One or both figurines not found! Check tags.");
        }
    }

    public void SwitchFigurine()
    {
        if (figurineA != null && figurineB != null)
        {
            bool isAActive = figurineA.activeSelf;
            figurineA.SetActive(!isAActive);
            figurineB.SetActive(isAActive);
        }
    }
}
