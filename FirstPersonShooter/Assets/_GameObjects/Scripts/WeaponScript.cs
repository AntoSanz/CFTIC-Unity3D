using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {
    private AudioSource audioSource;
    public enum Estado { Disponible, Descargada, Recargando, Disparando };
    public Estado estado = Estado.Disponible;

    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform spawnPoint;
    [SerializeField] AudioClip acDisparo;
    [SerializeField] AudioClip acRecarga;
    [SerializeField] AudioClip acCambioArma;
    [SerializeField] AudioClip acGatillazo;
    [SerializeField] int damageArma = 10;
    [SerializeField] float fuerzaArma = 100;
    [SerializeField] float cadencia;
    [SerializeField] float tiempoRecarga;
    [SerializeField] int municionCargador;
    [SerializeField] int capacidadCargador;
    [SerializeField] int numeroCargadores;
    [SerializeField] int cargadoresMaximos;

    [SerializeField] Text txtMunicion;
    [SerializeField] Text txtMaxMunicion;
    [SerializeField] Text txtCargadores;
    [SerializeField] Text txtMaxCargadores;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        txtMunicion.text = municionCargador.ToString();
        txtMaxMunicion.text = capacidadCargador.ToString();
        txtCargadores.text = numeroCargadores.ToString();
        txtMaxCargadores.text = cargadoresMaximos.ToString();
    }
    private void Update()
    {
        UpdateCanvas();
    }
    public void ApretarGatillo() {
        //print("ApretarGatillo");
        if (estado == Estado.Disponible) {
            Disparar();
        } else if (estado == Estado.Descargada) {
            audioSource.PlayOneShot(acGatillazo);
        }
    }
    private void Disparar() {
        //print("Disparar:" + gameObject.name);
        GameObject proyectil = Instantiate(prefabProyectil, spawnPoint.position, spawnPoint.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fuerzaArma);
        audioSource.PlayOneShot(acDisparo); //Reproducir el audio del disparo
        municionCargador--;

        UpdateCanvas();

        if (municionCargador == 0) {
            //CARGADOR VACIO
            estado = Estado.Descargada;
        } else {
            estado = Estado.Disparando;
            Invoke("ActivarArma", cadencia);
        }
    }
    public void Reload() {
        if (estado != Estado.Recargando && numeroCargadores > 0 && municionCargador != capacidadCargador) {
            estado = Estado.Recargando;
            numeroCargadores--;
            municionCargador = capacidadCargador;
            audioSource.PlayOneShot(acRecarga);
            Invoke("ActivarArma", tiempoRecarga);

            UpdateCanvas();
        }
    }

    private void ActivarArma() {
        this.estado = Estado.Disponible;

        UpdateCanvas();
    }
    public bool AddCargador(int _incrementoCargadores) {
        if (numeroCargadores < cargadoresMaximos) {
            numeroCargadores = Mathf.Min(numeroCargadores += _incrementoCargadores, cargadoresMaximos);

            UpdateCanvas();

            return true;
        } else {
            return false;
        }
    }
    public void UpdateCanvas()
    {
        txtMunicion.text = municionCargador.ToString();
        txtMaxMunicion.text = capacidadCargador.ToString();
        txtCargadores.text = numeroCargadores.ToString();
        txtMaxCargadores.text = cargadoresMaximos.ToString();
    }
}
