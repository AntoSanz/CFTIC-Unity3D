using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    /*
     score01 = 10;
     score02 = 20;

     * */
    //private void x()
    //{
    //    string json = JsonUtility.ToJson(listaPuntuaciones);
    //    JsonUtility.FromJson(json, Type.)
    //}


    private const string PKK_LEVEL_CODE = "SCORE_LVL_";
    private const string PKK_SCORE = "SCORE";
    public GameObject FinishCanvas;
    public int level;
    private const string SEPARADOR = ";";
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER))
        {
            print("ON_TRIGGER_ENTER");
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        ShowFinishCanvas();
        //GameManager.SaveScore(level);
        //SaveScore(level, GameManager.FormatScore);
    }

    private void ShowFinishCanvas()
    {
        FinishCanvas.SetActive(true);
    }
    /// <summary>
    /// Guarda el score del jugador en varias lineas
    /// </summary>
    /// <param name="_score"></param>
    //private void SaveScore(string _score)
    //{
    //    string levelCode = GetLevelCode();

    //    if (levelCode == PKK_LEVEL_CODE)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    print(levelCode + ": " + _score);

    //    PlayerPrefs.SetString(levelCode, _score);
    //    PlayerPrefs.Save();

    //    print(PlayerPrefs.GetString(levelCode));
    //}

    //private string GetLevelCode()
    //{
    //    //string _level = GameManager.Level.ToString();
    //    string _level = level.ToString();
    //    string _levelCode = PKK_LEVEL_CODE + _level;
    //    return _levelCode;
    //}

    /// <summary>
    /// Guarda el score del jugador en una sola linea
    /// </summary>
    /// <param name="level"></param>
    /// <param name="_score"></param>
    //private void SaveScore(int _level, string _score)
    //{
    //    string levelCode = GetLevelCode();
    //    //Formato "SCORE_LVL_X:00000;SCORE_LVL_Y:11111;"
    //    string formatScoreSaved = levelCode + ":" + _score + SEPARADOR;

    //    print(formatScoreSaved);
        
    //    PlayerPrefs.SetString(PKK_SCORE, formatScoreSaved);
    //    PlayerPrefs.Save();

    //    print(PlayerPrefs.GetString(PKK_SCORE));
    //}
}
