using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Camion : MonoBehaviour
{
    public Transform origin;
    public int speed = 1;

    private void Awake()
    {
        transform.position = origin.position;
    }

    void Start()
    {

    }

    void Update()
    {
        //Avanza el camión
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = origin.position;
    }
}