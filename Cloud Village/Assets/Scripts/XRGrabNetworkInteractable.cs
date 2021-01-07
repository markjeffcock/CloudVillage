using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;


public class XRGrabNetworkInteractable : XRGrabInteractable
{
    private PhotonView photonView; 
    private Vector3 initialAttachLocalPos;
    private Quaternion initialAttachLocalRot;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>(); 
        
        // Create attache Transform (if not existing
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initialAttachLocalPos = attachTransform.localPosition;
        initialAttachLocalRot = attachTransform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {

        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialAttachLocalPos;
            attachTransform.localRotation = initialAttachLocalRot;
        }

        photonView.RequestOwnership(); 
        base.OnSelectEnter(interactor);
    }
}
