using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoEnemyScript : MonoBehaviour
{
    [SerializeField] int AmmoDamage;
    [SerializeField] GameObject prefabImpacto;

    private void OnCollisionEnter(Collision collision) {
        //print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerScript>().RecibirDamage(AmmoDamage);
        }
        destroyAmmo();

    }

    /// <summary>
    /// Destruye el proyectil.
    /// </summary>
    private void destroyAmmo() {
        Instantiate(prefabImpacto, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
