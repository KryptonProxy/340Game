using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    //Students who worked on this script:
    //Carter Igo
    //Gary Stevens

    public void newGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("");
    }

    public void continueGame()
    {
        //string Level = PlayerPrefs.GetString("level", "nextlevel");
        //ChangeLevel.SwitchLevel(level: Level);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); //does not work in the editor, it works when you compile
#endif
    }

    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
