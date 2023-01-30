using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomScript : MonoBehaviour
{
    [SerializeField] GameObject[] prefabsEnemigo;
    [SerializeField] int timeBetweenSpawn;
    [SerializeField] GameObject prefabAparicion;
    [SerializeField] GameObject prefabBoss;
    private const int TIME_TO_DESTROY = 1;
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0, timeBetweenSpawn);
    }

    // Update is called once per frame
    private void GenerarEnemigo()
    {
        //generarAura();
        //Spawn de enemigos
        //bool gen = GameManager.GenerarMasEnemigos();
        
        if (GameManager.GenerarMasEnemigos())
        {
            GameManager.EnemyCount();
            int numeroEnemigos = prefabsEnemigo.Length;
            int indiceEnemigoAleatorio = Random.Range(0, numeroEnemigos);
            Instantiate(prefabsEnemigo[indiceEnemigoAleatorio], transform);
        }

        else if (!GameManager.GenerarMasEnemigos() && GameManager.GenerarBoss())
        {
            print("GenerarBoss");
            //GENERA BOSS

            Instantiate(prefabBoss, transform);
            GameManager.BossCount();
        }
    }
    private void generarAura()
    {
        //Aura de aparición
        Instantiate(prefabAparicion, this.transform.position, Quaternion.Euler(-90, 0, 0));

        //Destroy(this.gameObject, TIME_TO_DESTROY);

    }
}
