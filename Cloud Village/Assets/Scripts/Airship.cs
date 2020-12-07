using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Airship : MonoBehaviour
{
    private float baseSpeed = 0.1f;
    private float baseElevate = 0.0f;

    public Transform upDown;
    public Transform leftRight;
    public Transform forwardBack;

    public CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        Vector3 direction = new Vector3(baseSpeed, baseElevate, 0);

        // We'll move the airship forward at a basic speed
        transform.Translate(Vector3.left * Time.fixedDeltaTime * baseSpeed);

        // We'll move the airship up at a basic speed
        transform.Translate(Vector3.up * Time.fixedDeltaTime * baseElevate);

        // Move character (better if we only WHEN ON Airship)
        // Move direction to equal change in GLOBAL or LOCAL position?)

        //character.Move(direction * Time.fixedDeltaTime); This nearly worked

        //this seems to move in direction of character facing - i.e. still not a Global movement.
        character.transform.Translate(Vector3.left * Time.fixedDeltaTime * baseSpeed);
        character.transform.Translate(Vector3.up * Time.fixedDeltaTime * baseElevate);

    }
}
