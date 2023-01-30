using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] GameObject prefabEnemigo;
    [SerializeField] int timeBetweenSpawn = 5;
    void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0, timeBetweenSpawn);
    }
    private void GenerarEnemigo()
    {
        if (GameManager.eCount <= 50)
        {
            GameManager.EnemyCount();
            Instantiate(prefabEnemigo, this.transform);
        }

    }
}
