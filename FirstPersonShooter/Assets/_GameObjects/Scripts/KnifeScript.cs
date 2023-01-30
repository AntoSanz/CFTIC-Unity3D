using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript: MonoBehaviour
{
    public int damageCuchillos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().RecibirDamage(damageCuchillos);
            print("CUCHILLAZO AL ENEMIGO!");
        }
        transform.SetParent(collision.gameObject.transform);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.GetComponent<Collider>().enabled = false;
    }
}
