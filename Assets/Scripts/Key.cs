using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    //Students who worked on this script:
    //Gary Stevens

    //selector for the different key types
    [SerializeField] KeyType type;

    //a public list of enums for the key type
    public enum KeyType
    {
        Fire,
        Ice
        //tried to make this as modular as possible so keys can be added
    }

    //a public method to return the key type
    public KeyType GetKeyType()
    {
        //return the key type
        return type;
    }
}
