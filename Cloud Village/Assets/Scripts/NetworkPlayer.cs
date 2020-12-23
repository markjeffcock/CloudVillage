using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Animator leftHandAnimator;
    public Animator rightHandAnimator;
    public Material material2001;

    private PhotonView photonView;
    public SkinnedMeshRenderer robot;
    public int viewId;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        robot = transform.Find("Head/Robot Kyle/Robot2").GetComponent<SkinnedMeshRenderer>();
        viewId = photonView.ViewID;

        XRRig rig = FindObjectOfType<XRRig>();
        headRig = rig.transform.Find("Camera Offset/VR Camera");
        leftHandRig = rig.transform.Find("Camera Offset/Left Hand");
        rightHandRig = rig.transform.Find("Camera Offset/Right Hand");

        if (photonView.IsMine)
        {
            // temporary comment out to see overlap of heads/hand with Robot Kyle
             foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }

            // suggested in note for Valem M2 video
            foreach (var item in GetComponentsInChildren<Collider>())
            {
                item.enabled = false;
            }

        }

        // Change color of 2nd robot

        if (viewId == 2001)
        {
            robot.material = material2001; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
        }         

    }

    // Hand Animation

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }

    }

    void MapPosition(Transform target,Transform rigTransform)
    {

        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;

    }
}
