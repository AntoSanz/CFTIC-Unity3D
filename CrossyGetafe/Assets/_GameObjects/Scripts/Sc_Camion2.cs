using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Camion2 : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed;
    float porcentaje = 0.0f;

    void Start()
    {
        transform.position = startPoint.position;
    }

    void Update()
    {
        porcentaje = porcentaje + Time.deltaTime * speed;
        //El camión se traslada desde la posicion inicial hasta la final
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, porcentaje);
        //El camion gira!!
        transform.rotation = Quaternion.Lerp(startPoint.rotation, endPoint.rotation, porcentaje);
        if (porcentaje >= 1)
        {
            porcentaje = 0;
        }
    }
}
