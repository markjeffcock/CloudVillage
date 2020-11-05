using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourWine : MonoBehaviour
{
    public int pourThreshold = 90;
    public Transform origin = null;
    public GameObject wineStream = null;

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

    }

    private void EndPour()
    {

    }

    private float CalculatePourAng()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }
}
