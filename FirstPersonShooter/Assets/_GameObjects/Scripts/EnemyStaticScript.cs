using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaticScript : EnemyScript {
    enum Estado { Iddle, Attack, Reload };
    private Estado estado;
    public GameObject prefabBalas;
    public Transform spawnPoint;
    public float shootTime = 3;
    public Transform ejeRotacion;
    [SerializeField] float force = 100;

    private void Update() {
        if (estado == Estado.Attack) {
            ejeRotacion.LookAt(transformPlayer);
            //ejeRotacion.transform.Rotate(new Vector3(factorCorreccionAngulo, 0, 0));
            //Shoot();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //print("ENTRANDO RANGO TORRETA");
            estado = Estado.Attack;
            InvokeRepeating("Shoot", 1, shootTime);
        }
    }

    private void OnTriggerExit(Collider other) {
        //print("SALIENDO RANGO TORRETA");
        if (other.gameObject.CompareTag("Player")) {
            estado = Estado.Iddle;
            CancelInvoke();
        }
    }

    private void Shoot() {
        GameObject bullet = Instantiate(prefabBalas, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * force);
    }
}
