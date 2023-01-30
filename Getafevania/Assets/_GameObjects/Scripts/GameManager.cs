using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static Vector2 savePos;
    private static int points = 0;

    private static int level = 1;
    private static int lives = 1;
    public const int MAX_LIVES = 3;
    private const string PKK_CHECKPOINT_X = "lastX";
    private const string PKK_CHECKPOINT_Y = "lastY";
    private List<GameObject> bricks = new List<GameObject>();
    private const string FRAGILE_BOX = "FragileBox";
    //IMPLEMENTAR
    private const int POINTS_LENGTH = 6;
    private static string formatScore;

    private static bool savedLevel = false;
    private static Dictionary<int, string> scores = new Dictionary<int, string>();
    //private static List<KeyValuePair<int, string>> score = new List<KeyValuePair<int, string>>();


    //Dictionary<string, int> edades = new Dictionary<string, int>();

    //private void probar()
    //{
    //    int edad;
    //    edades.Add("Antonio", 18);
    //    if (edades.TryGetValue("Antonio", out edad))
    //    {
    //        print(edad);
    //    }
    //}

    //
    private void Awake()
    {
        savedLevel = false;
        
        //Lives = lives;
    }
    private void Start()
    {
        //Formateo para el canvas
        ScoreToString(points);
        //LoadPersistentScores();
        //Obtener puntuaciones persistentes
        //string scoreListInString = PlayerPrefs.GetString("SCORE");
        //StringToList(scoreListInString);
    }

    public static void AddPoints(int _points)
    {
        points = points + _points;
        ScoreToString(points);
    }

    public static void ScoreToString(int _score)
    {
        formatScore = _score.ToString();
        for (int i = 0; i < POINTS_LENGTH; i++)
        {
            if (i > formatScore.Length)
            {
                formatScore = "0" + formatScore;
            }
        }
    }

    public static void AddLive(int _lives)
    {
        lives = lives + _lives;
    }

    public static void SubstractLive()
    {
        lives = lives - 1;
        IsGameOver();
        if (IsGameOver())
        {
            ShowGameOver();
        }
        else
        {
            ResetScenario();
        }
    }

    private static void ShowGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public static void SaveData(Vector2 _savedPos)
    {
        savePos = _savedPos;
        PlayerPrefs.SetString(PKK_CHECKPOINT_X, savePos.x.ToString());
        PlayerPrefs.SetString(PKK_CHECKPOINT_Y, savePos.y.ToString());
        PlayerPrefs.Save();
    }

    public static bool IsGameOver()
    {
        bool isGameOver = false;
        return isGameOver = lives >= 0 ? false : true;
    }

    public static void ResetScenario()
    {
        GameManager gm = new GameManager();
        gm.ResetFragileBoxes();
    }

    public void ResetFragileBoxes()
    {
        var fragileBoxes = GameObject.FindGameObjectsWithTag(FRAGILE_BOX);
        //Añadir filtros para que las que no se han tocado, no las tenga en cuenta;
        foreach (var fragileBox in fragileBoxes)
        {
            fragileBox.gameObject.GetComponent<FragileBox>().ResetPosition();
        }
    }

    //GET+SET
    public static int Level {
        get {
            return level;
        }

        set {
            level = value;
        }
    }

    public static int Lives {
        get {
            return lives;
        }

        set {
            lives = value;
        }
    }

    public static int Points {
        get {
            return points;
        }

        set {
            points = value;
        }
    }

    public static string FormatScore {
        get {
            return formatScore;
        }

        set {
            formatScore = value;
        }
    }


    ////PUNTUACIONES
    //public static void SaveScoreInList(int _level)
    //{
    //    int index = _level - 1;

    //    //if (score[index] == null)
    //    //EXISTE?
    //    if (score.Count == 0 || score.Count < _level)
    //    {
    //        score.Add(formatScore);
    //    }
    //    else // if (score[_level - 1] != null)
    //    {
    //        score.Insert(_level - 1, formatScore);
    //    }
    //    string listToString = ListToString(score);
    //    print(score);
    //    PlayerPrefs.SetString("SCORE", score.ToString());
    //    PlayerPrefs.Save();
    //    savedLevel = true;
    //}
    //public static string ListToString(List<string> _list)
    //{
    //    string _formatList = string.Join(",", _list.ToArray());

    //    return _formatList;
    //}
    //public static void StringToList(string _formatList)
    //{
    //    char delimiter = ';';

    //    string[] split = _formatList.Split(delimiter);
    //    for (int i = 0; i < split.Length; i++)
    //    {
    //        score.Add(split[i]);
    //    }
    //}

    //GUARDAR PUNTUACIONES PERSISTENTES
    //public static void SaveScore(int _level)
    //{
    //    if (!savedLevel)
    //    {
    //        //int index = _level - 1;
    //        //La lista para guardar las puntuaciones se llama "score"

    //        //Añade todas las puntuaciones una detras de otra
    //        //NO
    //        //score.Add(formatScore);
    //        //string scoreListInString = SavedScoreToString(score);

    //        //PlayerPrefs.SetString("SCORE", scoreListInString);
    //        //PlayerPrefs.Save();
    //        //edades.Add("Antonio", 18);
    //        scores.Add(_level, formatScore);

    //        savedLevel = true;
    //    }
    //}
    /// <summary>
    /// Formatea una lista a string.
    /// </summary>
    /// <returns></returns>
    //public static string SavedScoreToString(List<string> _list)
    //{
    //    string listParsed = string.Join(";", _list.ToArray());
    //    return listParsed;
    //}
    //public static void SavedScoreToString(Dictionary<int, string> _dictionary)
    //{
    //    //string listParsed = string.Join(";", _dictionary);
    //    //return listParsed;
    //}
    //public static void LoadPersistentScores()
    //{
    //    string listParsed = PlayerPrefs.GetString("SCORE");
    //    StringToList(listParsed, score);
    //}
    /// <summary>
    /// Convierte un string separado por ';' y lo pushea a una lista.
    /// </summary>
    /// <param name="_listParsed"></param>
    //public static void StringToList(string _listParsed, List<string> _listName)
    //{
    //    char delimiter = ';';
    //    string[] split = _listParsed.Split(delimiter);

    //    for (int i = 0; i < split.Length; i++)
    //    {
    //        _listName.Add(split[i]);
    //    }
    //}
}
