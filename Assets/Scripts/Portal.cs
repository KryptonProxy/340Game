using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Students who worked on this level
//Carter Igo

public class Portal : MonoBehaviour
{
    public string targetLevel;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeLevel.SaveSettings("Level", paramValue: targetLevel);
        ChangeLevel.SwitchLevel(level: targetLevel);
    }
}
