using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileBox : MonoBehaviour
{
    private bool falling = false;
    public int units;
    public float delay;
    public float speed;
    private Vector2 initialPosition;

    private void Awake()
    {
        initialPosition = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!falling && collision.collider.CompareTag(Tags.PLAYER))
        {
            falling = true;
            Invoke("StartFall", delay);
        }
    }
    private void StartFall()
    {
        StartCoroutine("Fall");
    }
    IEnumerator Fall()
    {
        for (int i = 0; i < units; i++)
        {
            transform.Translate(0, -Time.deltaTime * speed, 0);
            yield return true;
        }
    }
    public void ResetPosition()
    {
        StopAllCoroutines();
        falling = false;
        transform.position = initialPosition;
    }
}
