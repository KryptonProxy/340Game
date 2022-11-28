using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //Students who worked on this script:
    //Gary Stevens

    public AudioSource soundEffect;
    public AudioClip clip;

    //selector for the different key types
    [SerializeField] Key.KeyType key;


    void Awake()
    {
        soundEffect = GetComponent<AudioSource>();
        clip = GetComponent<AudioClip>();
    }

    //a method to get the key type
    public Key.KeyType GetKeyType()
    {
        //return key
        return key;
    }

    //method to open the door
    public void OpenDoor()
    {
        soundEffect.PlayOneShot(clip);

        gameObject.SetActive(false);
        //this will change as the door could have an animation 
    }
}
