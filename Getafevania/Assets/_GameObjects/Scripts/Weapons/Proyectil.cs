using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
    public float force;
    public int damage;

	void Start () {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.ENEMY))
        {
            if (collision.gameObject.GetComponent<Bee>())
            {
                collision.gameObject.GetComponent<Bee>().ReceiveDamage(damage);
            }
            
        }
        if (collision.gameObject.CompareTag(Tags.ENEMY)
            || collision.gameObject.CompareTag(Tags.TERRAIN)
            || collision.gameObject.CompareTag(Tags.LAVA)
            || collision.gameObject.CompareTag(Tags.PLAYER)
            )
        {
            Destroy(gameObject);
        }
    }
}
