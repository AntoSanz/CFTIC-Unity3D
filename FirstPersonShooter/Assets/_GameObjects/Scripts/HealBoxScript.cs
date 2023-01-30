using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBoxScript : MonoBehaviour {
    [SerializeField] int cantidadSalud = 8;
    [SerializeField] private float velocidadGiro = 100f;
    void Update() {
        Rotar();
    }
    private void Rotar() {
        transform.Rotate(new Vector3(0, Time.deltaTime * velocidadGiro, 0));
    }
    private void OnTriggerEnter(Collider other) {
        //print("HEAL!");
        if (other.gameObject.CompareTag("Player")) {
            bool atope = other.gameObject.GetComponent<PlayerScript>().IncrementarSalud(cantidadSalud);
            if (atope == false) {
                Destroy(this.gameObject);
            }
        }
    }
}
