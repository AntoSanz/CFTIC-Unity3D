using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int damage; //Daño que provoca durante el ataque
    public int salud; //Salud del enemingo
    public GameObject prefabExplosion; //Prefab de la explosión
    public int distanciaDeteccion; //rango de vision para disparar
    public bool isBoss = false;
    protected Transform transformPlayer;
    private TextMesh tm;

    public virtual void Start()
    {
        transformPlayer = GameObject.Find("Player").transform;
        tm = GetComponentInChildren<TextMesh>();
        if (tm)
        {
            tm.text = salud.ToString();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        //1. Saber si ha colisionado con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().RecibirDamage(damage);
            //Si el enemigo que impacta con el jugador no es el boss MUERE
            if (!isBoss)
            {
                //Daño que hace el enemigo al jugador cuando choca con el.
                Morir();
            }
            //Si el enemigo que impacta con el jugador es el boss HACE DAÑO y se teletransporta a unos 10m
            if (isBoss)
            {
                print("IMPACTO BOSS");
            }
        }
    }
    /// <summary>
    /// Elimina al enemigo de pantalla e instancia prefabExplosion
    /// </summary>
    public void Morir()
    {
        print("Enemigo muerto");
        Instantiate(prefabExplosion, this.transform.position, Quaternion.identity);
        GameManager.EnemyKill();
        Destroy(this.gameObject);
    }
    /// <summary>
    /// Gestiona el daño recibido por los enemigos
    /// </summary>
    /// <param name="_damage">Daño entrante hecho al enemigo</param>
    public void RecibirDamage(int _damage)
    {
        print("Ouchi!");
        salud = salud - _damage;
        tm.text = salud.ToString();
        //salud = Mathf.Max(salud, 0);
        if (salud <= 0)
        {
            Morir();
        }
    }
}
