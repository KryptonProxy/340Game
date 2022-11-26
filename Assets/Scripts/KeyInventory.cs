using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{

    //Students who worked on this script:
    //Gary Stevens

    //private list of enum key types
    private List<Key.KeyType> keys;

    // Start is called before the first frame update
    void Start()
    {
        //on start, create the list
        keys = new List<Key.KeyType>();
    }

    //public method to add keys
    public void AddKey(Key.KeyType key)
    {
        //add key to the list
        keys.Add(key);
    }

    //public method to remove keys
    public void RemoveKey(Key.KeyType key)
    {
        //remove key from the list
        keys.Remove(key);
    }

    //public method to check keys being held
    public bool CheckKey(Key.KeyType key)
    {
        //return the key from the list
        return keys.Contains(key);
    }

    //private method to check collision on trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get collision with key
        Key key = collision.GetComponent<Key>();

        //if it isn't null and player is touching a key
        if(key != null)
        {
            //add they key to the list
            AddKey(key.GetKeyType());

            //destroy the key being touched
            Destroy(key.gameObject);
        }

        //get collision of a door
        Door door = collision.GetComponent<Door>();

        //if it isn't null and the player is in the vicinity of a door
        if (door != null)
        {
            //if the player has a key that matches the door
            if (CheckKey(door.GetKeyType()))
            {
                //remove the key
                RemoveKey(door.GetKeyType());

                //open the door
                door.OpenDoor();
            }
        }
    }


}


