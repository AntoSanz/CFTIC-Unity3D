using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Tags.PLAYER))
        {

            collision.gameObject.GetComponent<Player>().Die();
        }
    }
}