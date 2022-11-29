using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //Students who worked on this script:
    //Gary Stevens

    [SerializeField] AudioSource soundEffect;
    [SerializeField] AudioClip clip;

    //selector for the different key types
    [SerializeField] Key.KeyType key;

    //a method to get the key type
    public Key.KeyType GetKeyType()
    {
        //return key
        return key;
    }

    private void PlaySound()
    {
        soundEffect.PlayOneShot(clip);
    }

    private void DoorAnim()
    {
        //gameObject.SetActive(false);
        
        Destroy(gameObject);
    }

    //method to open the door
    public void OpenDoor()
    {
        Invoke("PlaySound", 0.1f);

        Invoke("DoorAnim", 1f); 


        //this will change as the door could have an animation 
    }
}
