using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int currentHealth = 750;

    // Start is called before the first frame update
    //Students who worked on his script:
    //Chase Casto
    //Gary Stevens


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
        //Causes a null exception on follow script upon death
        //Destroy(gameObject);
        SceneManager.LoadScene("Menu_MainMenu");
    }
}
