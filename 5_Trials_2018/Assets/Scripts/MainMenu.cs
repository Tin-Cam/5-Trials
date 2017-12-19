using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string startingScene;

    public void startGame(int difficulty)
    {
        //TODO: Make a diffculty setting

        SceneManager.LoadScene(startingScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
