using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchKnifeScript : MonoBehaviour
{
    public int cantidadCuchillos;
    //public int damageCuchillos;
    public float fuerzaLanzamiento;
    [SerializeField] GameObject prefabCuchillo;
    [SerializeField] Transform knifeSpawn;
    [SerializeField] EnemyScript enemyScript;
    private void Start()
    {
        enemyScript = gameObject.GetComponent<EnemyScript>();
    }
    public void LanzarCuchillo()
    {
        if (cantidadCuchillos > 0)
        {
            GameObject cuchillo = Instantiate(prefabCuchillo, knifeSpawn.position, knifeSpawn.rotation);
            cuchillo.GetComponent<Rigidbody>().AddForce(knifeSpawn.forward * fuerzaLanzamiento);
            cantidadCuchillos--;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        collision.gameObject.GetComponent<EnemyScript>().RecibirDamage(damageCuchillos);
    //        print("CUCHILLAZO AL ENEMIGO!");
    //    }
    //}
}
