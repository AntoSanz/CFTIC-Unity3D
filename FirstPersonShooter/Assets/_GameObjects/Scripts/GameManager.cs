using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int eCount = 0;
    public static int eKill = 0;
    public static int eBossCount = 0;
    public static int maxEnemy = 5;
    public static int bCount = 0;
    public static int maxBoss = 1;
    public static bool bossSpawned = false;

    /// <summary>
    /// EnemyCount lleva la cuenta de los enemigos que se han generado.
    /// </summary>
    public static void EnemyCount()
    {
        eCount++;
        print("eCount: " + eCount);
    }
    /// <summary>
    /// EnemyKill lleva la cuenta de los enemigos que hemos matado.
    /// </summary>
    public static void EnemyKill()
    {
        eKill++;
        print("eKill: " + eKill);
    }
    /// <summary>
    /// Comprobar si la creación de enemigos ha llevado a su limite.
    /// Devuelve true hasta que se llega al límite.
    /// </summary>
    /// <returns></returns>
    public static bool GenerarMasEnemigos()
    {
        bool gen = maxEnemy == eCount ? false : true;
        print("GenerarEnemigos: " + gen);
        return gen;
    }

    public static void BossCount()
    {
        bossSpawned = true;
    }
    /// <summary>
    /// Controla la aparición del enemigo "BOSS".
    /// Devuelve true cuando los enemigos que hemos matado llegan al límite de creación (Todos derrotados);
    /// NO CONTROLA LAS TORRETAS.
    /// </summary>
    /// <returns></returns>
    public static bool GenerarBoss()
    {
        bool gen = false;
        if (!bossSpawned)
        {
            gen = maxEnemy == eKill ? true : false;
        }
        return gen;

    }
}
