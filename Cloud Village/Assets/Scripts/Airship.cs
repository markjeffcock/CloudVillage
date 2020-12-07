using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airship : MonoBehaviour
{
    private float baseSpeed = 0.1f;
    private float baseElevate = 0.1f;

    public Transform upDown;
    public Transform leftRight;
    public Transform forwardBack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We'll move the airship forward at a basic speed
        transform.Translate(Vector3.left * Time.deltaTime * baseSpeed);

        // We'll move the airship up at a basic speed
        transform.Translate(Vector3.up * Time.deltaTime * baseElevate);
    }
}
