using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {
    public void changeScene(string nextScene)
    {
        Application.LoadLevel(nextScene);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
