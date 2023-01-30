using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxScript : MonoBehaviour {
    [SerializeField] int incrementoCargadores;
    [SerializeField] private float velocidadGiro;

    void Update() {
        Rotar();
    }
    /// <summary>
    /// Rota la caja.
    /// </summary>
    private void Rotar() {
        transform.Rotate(new Vector3(0, Time.deltaTime * velocidadGiro, 0));
    }
    private void OnTriggerEnter(Collider other) {
        //print("AMMO!");
        if (other.gameObject.CompareTag("Player")) {
            //Aumentar el numero de cargadores disponibles para el arma.
            WeaponScript arma = other.gameObject.GetComponentInChildren<WeaponScript>();
            bool reload = arma.AddCargador(incrementoCargadores);
            if (reload) {
                Destroy(this.gameObject);
            }
        }
    }
}
