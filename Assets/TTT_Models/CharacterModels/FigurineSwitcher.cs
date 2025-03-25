using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurineSwitcher : MonoBehaviour
{
    public GameObject[] figurines; // Array of figurines
    private int currentIndex = 0; // Tracks the active figurine

    void Start()
    {
        // Ensure only the first figurine is active at the start
        for (int i = 0; i < figurines.Length; i++)
        {
            figurines[i].SetActive(i == 0); // Activate only the first figurine
        }
    }

    public void SwapFigurine()
    {
        // Disable the current figurine
        figurines[currentIndex].SetActive(false);

        // Move to the next figurine in the cycle
        currentIndex = (currentIndex + 1) % figurines.Length;

        // Enable the new figurine
        figurines[currentIndex].SetActive(true);
    }


}
