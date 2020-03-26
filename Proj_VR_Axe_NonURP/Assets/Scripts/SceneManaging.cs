using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Kas made this script
public class SceneManaging : MonoBehaviour
{
    public string sceneName;

    public void ChangeTheScene()
    {
        SceneManager.LoadScene(sceneName);
    }


    //quit game
    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Game has quitted");
    }
}
