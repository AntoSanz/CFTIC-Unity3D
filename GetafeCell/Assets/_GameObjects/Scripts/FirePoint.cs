using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{

    [SerializeField] GameObject prefabProyectil;
    public float force;
    public void Fire()
    {
        GameObject proyectil = Instantiate(prefabProyectil, this.transform.position, this.transform.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(this.transform.forward * force);
    }
}