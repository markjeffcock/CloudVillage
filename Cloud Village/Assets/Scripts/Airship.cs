using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Airship : MonoBehaviour
{
    private float baseSpeed = 0.2f;
    private float baseElevate = 0.2f;

    public Transform upDown;
    public Transform leftRight;
    public Transform forwardBack;

    public CharacterController character;
    public Collider onBoard;

    private Vector3 lastFramePosition;
    private Quaternion lastFrameRotation;
    private Vector3 vehicleMovement;
    private Quaternion vehicleRotation;

    private Vector3 currentPlayerPosition;

    // Start is called before the first frame update
    // Initialise values to avoid nulls
    void Start()
    {
        lastFramePosition = transform.position;
        lastFrameRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        currentPlayerPosition = character.gameObject.transform.position;

        // Only Move if someone on Board

        if (onBoard.bounds.Contains(currentPlayerPosition))
        {
            // Vehicle movement since last frame
            vehicleMovement = transform.position - lastFramePosition;
            vehicleRotation = transform.rotation * Quaternion.Inverse(lastFrameRotation);

            // Capture current position
            lastFramePosition = transform.position;
            lastFrameRotation = transform.rotation;

            // We'll move the airship forward at a basic speed
            transform.Translate(Vector3.left * Time.fixedDeltaTime * baseSpeed);

            // We'll move the airship up at a basic speed
            transform.Translate(Vector3.up * Time.fixedDeltaTime * baseElevate);

            // Move character (better if we only WHEN ON Airship)
            // Character MOVe not working when we capture small current positions (as above) 
            // Idea A (not with deltaTime)
            // Idea: change to Move to Wheel Position (after making this work ONLY when on Airship)
            // Idea 2: try character.SImpleMove
            // Idea 3: try transform of character to WheelPosition
            // TempIdea - large box collider behind character.

            // Initial version character.Move(vehicleMovement * Time.fixedDeltaTime); 
            character.Move(vehicleMovement);
        }

    }
}
