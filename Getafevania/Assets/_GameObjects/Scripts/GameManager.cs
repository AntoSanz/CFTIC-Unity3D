﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static int points = 00000;
    private static int level = 1;
    private static int lives = 3;

    public static void AddPoints(int _points)
    {
        points = points + _points;
    }
    public static void AddLive(int _lives)
    {
        lives = lives + _lives;
    }
    public static int Points {
        get {

            return points;
        }

        set {
            points = value;
        }
    }
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
}