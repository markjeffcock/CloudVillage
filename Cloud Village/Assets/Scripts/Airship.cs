using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Airship : MonoBehaviour
{
    private float baseSpeed = 0.1f;
    private float baseElevate = 0.1f;

    public Transform leftRight;
    public Transform forwardBack;
    public Transform upDown;

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

        //Check Control positions


    }
}
//            // where are my Reins?
//            using TMPro;
//             public Transform rightRein;
//public TextMeshProUGUI debugText;
//rightRein = GameObject.Find("Rein Right").GetComponent<Transform>();
//            leftRein = GameObject.Find("Rein Left").GetComponent<Transform>();
//            reinGap = rightRein.position.x - leftRein.position.x;
//            reinRotation = (leftRein.rotation.z + rightRein.rotation.z)/2 ;
//            reinRotation = -reinRotation;
//            debugText.text = "ReinGap " + reinGap + " ReinRotation " + reinRotation;
