using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Animator leftHandAnimator;
    public Animator rightHandAnimator;
    //public Material material2001;
    public Material[] materialChange = new Material[20];

    private PhotonView photonView;
    public SkinnedMeshRenderer robot;
    public int viewId;
    public TMP_Text displayViewId;

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

        // Show ViewId on forehead
        displayViewId.text = "" + viewId;

        // Change color of Robots

        if (viewId == 2001)
        {
            robot.material = materialChange[1]; 
        }
        if (viewId == 3001)
        {
            robot.material = materialChange[2];
        }
        if (viewId == 4001)
        {
            robot.material = materialChange[3];
        }
        if (viewId == 5001)
        {
            robot.material = materialChange[4];
        }
        if (viewId == 6001)
        {
            robot.material = materialChange[5];
        }
        if (viewId == 7001)
        {
            robot.material = materialChange[6];
        }
        if (viewId == 8001)
        {
            robot.material = materialChange[7];
        }
        if (viewId == 9001)
        {
            robot.material = materialChange[8];
        }
        if (viewId == 10001)
        {
            robot.material = materialChange[9];
        }
        if (viewId == 11001)
        {
            robot.material = materialChange[10];
        }
        if (viewId == 12001)
        {
            robot.material = materialChange[11];
        }
        if (viewId == 13001)
        {
            robot.material = materialChange[12];
        }
        if (viewId == 14001)
        {
            robot.material = materialChange[13];
        }
        if (viewId == 15001)
        {
            robot.material = materialChange[14];
        }
        if (viewId == 16001)
        {
            robot.material = materialChange[15];
        }
        if (viewId == 17001)
        {
            robot.material = materialChange[16];
        }
        if (viewId == 18001)
        {
            robot.material = materialChange[17];
        }
        if (viewId == 19001)
        {
            robot.material = materialChange[18];
        }
        if (viewId == 20001)
        {
            robot.material = materialChange[19];
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
