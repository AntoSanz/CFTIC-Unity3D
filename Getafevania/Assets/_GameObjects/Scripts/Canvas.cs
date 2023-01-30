using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    [SerializeField] GameObject panelMenu;
    public Text txtScore;
    public Image[] imgLives;

    void Start()
    {

        txtScore.text = GameManager.FormatScore;

        foreach (Image img in imgLives)
        {
            img.enabled = false;
        }
    }

    void Update()
    {
        PrintScore();
        PrintLives();
        ShowPauseMenu();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ContinuePlaying()
    {
        panelMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void ShowPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelMenu.SetActive(!panelMenu.activeSelf);
            Time.timeScale = (panelMenu.activeSelf) ? 0 : 1;
        }
    }

    private void PrintScore()
    {
        txtScore.text = GameManager.FormatScore;
    }

    private void PrintLives()
    {
        //Desactivar todos los corazones
        for (int i = 0; i < GameManager.MAX_LIVES; i++)
        {
            imgLives[i].enabled = false;
        }
        //Activar todos los corazones correspondientes a las vidas que tenemos
        for (int i = 0; i < GameManager.Lives; i++)
        {
            imgLives[i].enabled = true;
        }
    }
}
