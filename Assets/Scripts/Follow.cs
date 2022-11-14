using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    //Students who worked on this script:
    //Gary Stevens

    public GameObject objectToFollow;

    public float lerpPerFrame = 0.01f;

    public bool lockYAxis = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objPos = objectToFollow.transform.position;

        objPos.z = transform.position.z;

        if (lockYAxis)
        {
            objPos.y = transform.position.y;
        }
        
        transform.position=Vector3.Lerp(transform.position, objPos, lerpPerFrame);
    }
}
