using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectil : MonoBehaviour
{
    public float force;
    public int damage;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(Tags.PLAYER))
        {
            collision.gameObject.GetComponent<Player>().ReceiveDamage(damage);
        }
        Destroy(gameObject);
    }
}
