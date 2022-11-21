using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //Students who worked on this script:
    //Gary Stevens

    //selector for the different key types
    [SerializeField] Key.KeyType key;

    //a method to get the key type
    public Key.KeyType GetKeyType()
    {
        //return key
        return key;
    }

    //method to open the door
    public void OpenDoor()
    {
        gameObject.SetActive(false);
        //this will change as the door could have an animation 
    }
}
