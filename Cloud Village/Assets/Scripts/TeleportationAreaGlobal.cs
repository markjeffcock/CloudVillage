using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace UnityEngine.XR.Interaction.Toolkit
{
    public class TeleportationArea : BaseTeleportationInteractable
    {

        protected override bool GenerateTeleportRequest(XRBaseInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
        {
            teleportRequest.destinationPosition = raycastHit.point;
            teleportRequest.destinationUpVector = Vector3.up; // use the area transform for data.
            teleportRequest.destinationForwardVector = Vector3.forward;
            teleportRequest.destinationRotation = Quaternion.identity;
            return true;
        }
    }
}