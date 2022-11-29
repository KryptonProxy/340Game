using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    Animator starCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        starCheckpoint = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            starCheckpoint.SetBool("gotCheck", true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
