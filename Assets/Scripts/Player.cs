using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //Students who worked on this script:
    //Gary Stevens

    Rigidbody2D rigidBody;

    Animator animator;

    SpriteRenderer spriteRenderer;

    public float speed = 10;

    public float jumpPower = 10;

    float horizontalMovement;

    bool isJumping = false;

    bool canJump = false;

    Vector3 respawnPoint;

    public AudioSource soundSource;

    public ParticleSystem paricle1;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX", -7), PlayerPrefs.GetFloat("PlayerY", 0), 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        isJumping = Input.GetAxis("Jump") > 0 ? true : false;

        if(Input.GetAxis("Cancel") == 1)
        {
            PlayerPrefs.SetFloat("PlayerX", respawnPoint.x);

            PlayerPrefs.SetFloat("PlayerY", respawnPoint.y);

            PlayerPrefs.Save();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); //does not work in the editor, it works when you compile
#endif
        }
    }

    private void FixedUpdate()
    {
        var hasPlayed = true;

        if (transform.position.y < -10)
        {
            rigidBody.velocity = Vector2.zero;

            transform.position = respawnPoint;
        }

        rigidBody.velocity = new Vector2(horizontalMovement * speed, rigidBody.velocity.y);

        if (isJumping)
        {
            Vector3 feetPosition = transform.GetChild(0).position;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(feetPosition, 0.25f);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject == gameObject)
                {
                    continue;
                }

                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);

                rigidBody.AddForce(Vector2.up * jumpPower);

                break;
            }
        }

        if (rigidBody.velocity.magnitude > 0.05f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (rigidBody.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (rigidBody.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }


}
