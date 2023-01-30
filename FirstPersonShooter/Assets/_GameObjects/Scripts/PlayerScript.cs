using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    [SerializeField] Text txtVida;
    [SerializeField] int salud = 100;
    [SerializeField] WeaponScript[] armas;
    [SerializeField] LaunchKnifeScript launchKnifeScript;

    private const int SALUD_MAXIMA = 100;
    private bool esInmune;
    private bool estaVivo;
    public int armaActiva = 0;

    void Start() {
        txtVida.text = salud.ToString();
        launchKnifeScript = gameObject.GetComponent<LaunchKnifeScript>();
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Disparar();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            armas[armaActiva].Reload();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            CambiarArma(1);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            launchKnifeScript.LanzarCuchillo();
        }
    }
    private void CambiarArma(int _armaActivar)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].gameObject.SetActive(false);
        }
        armas[_armaActivar].gameObject.SetActive(true);
        armaActiva = _armaActivar;
    }
    public void RecibirDamage(int damage) {
        salud = salud - damage;
        salud = Mathf.Max(salud, 0);
        txtVida.text = salud.ToString();
    }
    public bool IncrementarSalud(int incremento) {
        bool atope = true;
        //print("IncrementarSalud");
        if (salud < SALUD_MAXIMA) {
            salud = salud + incremento;
            salud = Mathf.Min(salud, SALUD_MAXIMA);
            txtVida.text = salud.ToString();
            atope = false;
        }
        return atope;
    }
    private void Disparar() {
        armas[armaActiva].ApretarGatillo();
        //armas[0].GetComponent<WeaponScript>().ApretarGatillo();
    }
    private void Dead() {

    }
}