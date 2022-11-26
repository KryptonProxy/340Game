using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unstable_Platform : MonoBehaviour
{

    //Students who worked on this script:
    //Gary Stevens

    //rigidbody
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody component
        rigidBody = GetComponent<Rigidbody2D>();
    }

    //method to drop the platform
    void DropPlatform()
    {
        //set rigidBody to dynamic so it will fall
        rigidBody.isKinematic = false;
    }

    //method to determine collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the object collides with player
        if(collision.gameObject.Equals("Player"))
        {
            //call the drop platform after half a second
            Invoke("DropPlatform", 0.5f);

            //destroy the object after 2 seconds
            Destroy(gameObject, 2f);
        }
    }


}
