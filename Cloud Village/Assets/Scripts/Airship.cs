using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Airship : MonoBehaviour
{
    private float baseSpeed = 0.0f;
    private float baseElevate = 0.0f;
    private float baseTwist = 0.0f;

    public Transform upDown;
    public Transform leftRight;
    public Transform forwardBack;

    public CharacterController character;
    public Collider onBoard;

    private float initialUpDownRotation;
    private float upDownRotation;
    public float upDownModifier;
    private float initialLeftRightRotation;
    private float leftRightRotation;
    public float leftRightModifier; 
    private float initialForwardBackRotation;
    private float forwardBackRotation;
    public float forwardBackModifier;

    private Vector3 lastFramePosition;
    private Quaternion lastFrameRotation;
    private Vector3 vehicleMovement;
    private Quaternion vehicleRotation;

    private Vector3 currentPlayerPosition;

    public GameObject Rotate1;
    public GameObject Rotate2;

    // Start is called before the first frame update
    // Initialise values to avoid nulls
    void Start()
    {
        lastFramePosition = transform.position;
        lastFrameRotation = transform.rotation;
        initialForwardBackRotation = forwardBack.localRotation.x;
        initialUpDownRotation = upDown.localRotation.z;
        initialLeftRightRotation = leftRight.localRotation.x;
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        //CHeck Postion of the player character & controls
        
        currentPlayerPosition = character.gameObject.transform.position;
        forwardBackRotation = forwardBack.localRotation.x;
        upDownRotation = upDown.localRotation.z;
        leftRightRotation = leftRight.localRotation.x;

        // Only Move if someone on Board

        if (onBoard.bounds.Contains(currentPlayerPosition))
        {
            // Vehicle movement since last frame
            vehicleMovement = transform.position - lastFramePosition;
            vehicleRotation = transform.rotation * Quaternion.Inverse(lastFrameRotation);
            

            // Capture current position of Airship
            lastFramePosition = transform.position;
            lastFrameRotation = transform.rotation;

            // We'll move the airship forward at a basic speed (dependednt on position of Handle)
            baseSpeed = (forwardBackRotation - initialForwardBackRotation) * forwardBackModifier;
            transform.Translate(Vector3.left * Time.fixedDeltaTime * baseSpeed);

            // We'll move the airship up at a basic speed
            baseElevate = (upDownRotation - initialUpDownRotation) * upDownModifier;
            transform.Translate(Vector3.up * Time.fixedDeltaTime * baseElevate);

            // We rotate the airship
            baseTwist = (leftRightRotation - initialLeftRightRotation) * leftRightModifier;
            transform.Rotate(0, Time.fixedDeltaTime * baseTwist, 0);

            // Move the Player in step with the Airship
            character.Move(vehicleMovement);
            character.transform.Rotate(0, Time.fixedDeltaTime * baseTwist, 0);

            //Rotate any Propellers
            Rotate1.transform.Rotate(0, 3 * baseSpeed, 0);
            Rotate2.transform.Rotate(0, 3 * baseSpeed, 0);
        }

    }
}

