using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    //Worked on this script
    //Gary Stevens

    private float timer;

    private int fallCount = 0;

    public bool CurrentState()
    {
        if(timer > 0)
        {
            return false;
        }
        return fallCount > 0;
    }

    private void OnEnable()
    {
        fallCount = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        fallCount++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        fallCount--;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void Disable(float duration)
    {
        timer = duration;
    }
}
