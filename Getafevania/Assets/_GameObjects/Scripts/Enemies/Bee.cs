using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour {
    public int health;
    [SerializeField] Transform endPos;
    [SerializeField] float speed;
    [SerializeField] GameObject prefabExplosion;
    Vector3 initPos;
    [SerializeField] int damage;

    float pct = 0;
    private void Awake()
    {
        initPos = transform.position;
    }

    void Update () {
        pct = pct + Time.deltaTime * speed; 
        if (pct>=1 || pct <= 0)
        {
            speed = speed * -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            if (pct > 1)
            {
                pct = 1;
            } else if (pct < 0)
            {
                pct = 0;
            }
        }
        transform.position = Vector2.Lerp(initPos, endPos.position, pct);
	}
    public void ReceiveDamage(int _damage)
    {
        health = health - _damage;
        GetComponentInChildren<Slider>().value = health;
        if (health <= 0 )
        {
           // Instantiate(prefabExplosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag(Tags.PLAYER))
        {
            collision.gameObject.GetComponent<Player>().ReceiveDamage(damage);
        }
    }
}
