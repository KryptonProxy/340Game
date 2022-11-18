using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool ChangeHealth(int changeValue)
    {
        currentHealth = currentHealth + changeValue;
        if (currentHealth <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
