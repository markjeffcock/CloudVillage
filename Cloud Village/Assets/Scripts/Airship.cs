using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Airship : MonoBehaviour
{
    private float baseSpeed = 0.1f;
    private float baseElevate = 0.1f;

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
        Vector3 direction = new Vector3(baseSpeed, 0, baseElevate);

        // We'll move the airship forward at a basic speed
        transform.Translate(Vector3.left * Time.fixedDeltaTime * baseSpeed);

        // We'll move the airship up at a basic speed
        transform.Translate(Vector3.up * Time.fixedDeltaTime * baseElevate);

        // Move character
        character.Move(direction * Time.fixedDeltaTime);
    }
}
