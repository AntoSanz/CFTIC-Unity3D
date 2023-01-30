using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Pollo : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] int force = 1;
    Vector3 saltito;
    [SerializeField] float v3x = 0;
    [SerializeField] float v3y = 0;
    [SerializeField] float v3z = 0;
    [SerializeField] GameObject prefabDeath;
    [SerializeField] Transform checkPointPos;
    [SerializeField] float radio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        saltito = new Vector3(v3x, v3y, v3z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstaEnElSuelo())
        {
            rb.AddRelativeForce(saltito * force);
        }
    }
    private bool EstaEnElSuelo()
    {
        bool enSuelo = false;
        Collider[] colliders = Physics.OverlapSphere(checkPointPos.position, radio);
        print(colliders.Length);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.CompareTag("Floor"))
            {
                enSuelo = true;
                break;
            }
        }
        return enSuelo;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Camion"))
        {
            Dead();
        }
    }
    void Dead()
    {
        Instantiate(prefabDeath, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
