using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    [SerializeField] GameObject proyectil;
    public void Fire()
    {
        Instantiate(proyectil, transform.position, transform.rotation);
    }
}
