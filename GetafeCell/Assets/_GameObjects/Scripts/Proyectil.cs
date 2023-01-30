using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    private const string VIGILANTE = "Vigilante";
    [SerializeField] GameObject prefabImpacto;

    private void OnCollisionEnter(Collision collision)
    {
        destroyProyectil();
    }
    private void destroyProyectil()
    {
        if (prefabImpacto)
        {
            GameObject[] vigilantes = GameObject.FindGameObjectsWithTag(VIGILANTE);
            foreach (var vigilante in vigilantes)
            {
                vigilante.GetComponent<Douglas>().SetTaunt(transform.position);
            }
            Instantiate(prefabImpacto, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
