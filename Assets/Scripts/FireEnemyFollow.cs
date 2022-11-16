using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyFollow : MonoBehaviour
{
    //People who worked on his script:
    //Carter


    public GameObject targetObject;
    public Transform targetTransform;
    public Vector3 targetPosition;

    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;

    public float Range = 2;
    public float speed = 2;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if (targetTransform == null)
        {
            targetTransform = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(targetTransform != null)
        {
            targetPosition = targetTransform.position;
        }
        else if (targetObject != null)
        {
            targetPosition = targetObject.transform.position;
        }
    }

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude > 0.01f)
        {
            anim.SetBool("RunTrue", true);
        }
        else
        {
            anim.SetBool("RunTrue", false);
        }
        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
    }
}
