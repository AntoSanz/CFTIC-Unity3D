using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    [SerializeField] int ammoDamage = 1;
    [SerializeField] GameObject prefabImpacto;
    [SerializeField] float timeToDestroy = 3;

    private void Start()
    {
        Invoke("destroyAmmo", timeToDestroy);
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<EnemyScript>().RecibirDamage(ammoDamage);
            print("IMPACTO ENEMIGO!");            
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
