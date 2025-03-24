using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurineSwitcher : MonoBehaviour
{
    public GameObject FigurineA;
    public GameObject FigurineB;

    private bool isFigurineAActive = true;

    public void SwapFigurine()
    {
        Transform activeTransform = isFigurineAActive ? FigurineA.transform : FigurineB.transform;

        isFigurineAActive = !isFigurineAActive;

        if (isFigurineAActive)
        {
            FigurineA.transform.SetPositionAndRotation(activeTransform.position, activeTransform.rotation);
        }
        else
        {
            FigurineB.transform.SetPositionAndRotation(activeTransform.position, activeTransform.rotation);
        }


        FigurineA.SetActive(isFigurineAActive);
        FigurineB.SetActive(!isFigurineAActive);


    }

  
}
