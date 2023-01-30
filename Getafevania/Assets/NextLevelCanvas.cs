using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelCanvas : MonoBehaviour
{


    public void GoToNextLevel()
    {
        GoTo("GameScene1");
    }
    public void GoToMainMenu()
    {
        GoTo("MenuScene");
    }
    private void GoTo(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }
}
