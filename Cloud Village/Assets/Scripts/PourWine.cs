using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourWine : MonoBehaviour
{
    public int pourThreshold = 90;
    public GameObject wineStream;

    private bool isPouring = false;
   

    // Update is called once per frame
    private void Update()
    {
        bool pourCheck = CalculatePourAng() < pourThreshold;

        if(isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if(isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

 
    private void StartPour()
    {
        wineStream.SetActive(false);
    }

    private void EndPour()
    {
        wineStream.SetActive(false);
    }

    private float CalculatePourAng()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }
}
