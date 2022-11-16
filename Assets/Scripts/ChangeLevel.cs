using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string targetLevel;

    public static void SwitchLevel(bool restartCurrent = false, string level = "")
    {
        if (restartCurrent)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            SceneManager.LoadScene(level);
    }

    public static void SaveSettings(string paramName, string paramValue)
    {
        Player playerObject = FindObjectOfType<Player>();

        if (playerObject != null)
        {
            PlayerPrefs.SetInt("Health", playerObject.Health);
            PlayerPrefs.Save();
        }
    }
}
