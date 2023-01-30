using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float linearSpeed;
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private float x;
    private float y;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Walk();
    }
    private void Walk()
    {
        if (Mathf.Abs(x) > 0) {
            rb2d.velocity = new Vector2(x * linearSpeed, 0);

            //HACER QUE EL SPRITE SE GIRE SEGUN LA DIRECCIÓN EN LA QUE ANDA
            //Opcion 1
            //if (x > 0) {
            //    transform.localRotation = Quaternion.Euler(0, 0, 0);
            //}
            //else {
            //    transform.localRotation = Quaternion.Euler(0, 180, 0);
            //}
            //Opcion 2
            //if (x < 0) {
            //    sr.flipX = true;
            //}
            //if (x > 0) {
            //    sr.flipX = false;
            //}
            //Opcion 3
            //sr.flipX = x < 0 ? true : false;
            //Opcion 4
            sr.flipX = (x < 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ITEM");
        if (collision.CompareTag(Tags.ITEM)) {
            collision.gameObject.GetComponent<Item>().DoAction();
        }
    }
}
