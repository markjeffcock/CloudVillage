using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    public Animator LightSaberAnimator;
    public void TurnOnLightSaber()
    {
        LightSaberAnimator.SetTrigger("Turn Light Saber On");
        LightSaberAnimator.ResetTrigger("Turn Light Saber Off");

    }

    public void TurnOffLightSaber()
    {
        LightSaberAnimator.SetTrigger("Turn Light Saber Off");
        LightSaberAnimator.ResetTrigger("Turn Light Saber On");

    }
}
