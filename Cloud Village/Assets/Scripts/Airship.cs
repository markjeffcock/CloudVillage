using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airship : MonoBehaviour
{
    private float baseSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We'll move the airship forward at a basic speed
        transform.Translate(Vector3.left * Time.deltaTime * baseSpeed);

    }
}
