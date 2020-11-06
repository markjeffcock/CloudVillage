using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourWine : MonoBehaviour
{
    public int pourThreshold = 90;
    public GameObject wineStream;
    public Transform wineBottle;
    public Transform bottleTop;

    private bool isPouring = false;
    private bool pourCheck;
    public float bottleTopHeight;
    public float bottleMidHeight;


    // Update is called once per frame
    private void Update()
    {
        bottleMidHeight = wineBottle.position.y;
        bottleTopHeight = bottleTop.position.y;

       // bool pourCheck = CalculatePourAng() < pourThreshold;

        if ((bottleTopHeight-bottleMidHeight) < 0)
        {
            pourCheck = true;
        }
        else
        {
            pourCheck = false;
        }

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
        wineStream.SetActive(true);
    }

    private void EndPour()
    {
        wineStream.SetActive(false);
    }

    //private float CalculatePourAng()
    //{
    //   
    //}
}
