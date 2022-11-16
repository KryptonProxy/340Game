using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Students who worked on this script:
    //Gary Stevens
    //Chase Casto

    Rigidbody2D rigidBody;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float speed = 10;
    public float jumpPower = 10;
    float horizontalMovement;

    bool isJumping = false;

    Vector3 respawnPoint;

    [HideInInspector]
    public Text healthText;
    [HideInInspector]
    public Health healthReference;

    public int Health//Creates an int that utilizing the Health class.
    {
        get { return healthReference.currentHealth; }
        set
        {
            healthReference.currentHealth = value;
            healthText.text = "Health: " + healthReference.currentHealth;
        }
    }

    public AudioSource soundSource;
    public ParticleSystem paricle1;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        healthReference = GameObject.Find("Player").GetComponent<Health>();//Establishes a reference to the player's health.
        healthText = GameObject.Find("Health").GetComponent<Text>();//Finds the health text component.
        Health = PlayerPrefs.GetInt("Health", healthReference.currentHealth);//Allows us to carry the Health component to other levels.

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
        if (transform.position.y < -10)
        {
            rigidBody.velocity = Vector2.zero;
            transform.position = respawnPoint;

            bool isKilled = healthReference.ChangeHealth(-250);//A bool that will change the players health if the conditions are satisfied.
            Health = healthReference.currentHealth;//Sets health equal to the current health.
            if (isKilled)//If the player's health reaches 0, then they will be sent to the MainMenu.
            {
                SceneManager.LoadScene("MainMenu");
            }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "CheckPoint":
                respawnPoint = collision.gameObject.transform.position;
                break;
            case "HealthBoost":
                healthReference.ChangeHealth(250);//Increases the players Health by 250.
                Health = healthReference.currentHealth;//Sets health equal to the current health.
                Destroy(collision.gameObject);//Destroys the object.
                break;
            case "JumpBoost":
                jumpPower = 1000;//Increases jump power.
                Destroy(collision.gameObject);//Destroys the object.
                break;
            case "JumpPad":
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);//IN PROGRESS.
                rigidBody.AddForce(Vector2.up * 1000);//Launches the player.
                break;
            default:
                Debug.Log("Probably a tag is missing");
                break;
        }
    }
}
