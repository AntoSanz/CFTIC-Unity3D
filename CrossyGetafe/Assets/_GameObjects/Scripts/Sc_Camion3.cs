using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Camion3 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float deltaDistancia;
    [SerializeField] Transform origin;

    private void Start()
    {
        this.transform.position = origin.position;
        StartCoroutine(Mover(deltaDistancia));
    }

    void Update()
    {

    }

    IEnumerator Mover(float _deltaDistancia)
    {
        for (int i = 0; i < _deltaDistancia; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            yield return null;
        }
    }

}