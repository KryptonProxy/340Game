using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireEnemyFollow : MonoBehaviour
{
    //Students who worked on his script:
    //Carter

    //This is an emeny meant to chase the player once they get into a certain range

    public GameObject targetObject;
    public Transform targetTransform;
    public Vector3 targetPosition;

    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    GameObject other;
    AudioSource soundEffect;

    public float Range = 2;
    public float speed = 2;
    public int damage = -250;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        soundEffect = gameObject.GetComponent<AudioSource>();
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
        Vector3 directionVector = targetPosition - transform.position;
        float distanceToTarget = directionVector.magnitude;
        directionVector.Normalize();
        if (distanceToTarget > Range)
        {
            anim.SetBool("RunTrue", false);
            return;
        }
        else
        {
            soundEffect.Play();
            anim.SetBool("RunTrue", true); 
        }
        transform.position += directionVector * speed * Time.deltaTime;
        if (directionVector.x > 0)
        {
            sr.flipX = true;
        }
        else if (directionVector.x < 0)
        {
            sr.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            other = collision.gameObject;
            bool isKilled = other.GetComponent<Health>().ChangeHealth(damage);
            if (isKilled)
            {
                SceneManager.LoadScene("Menu_MainMenu");
            }
            Destroy(gameObject);
        }
    }

}
