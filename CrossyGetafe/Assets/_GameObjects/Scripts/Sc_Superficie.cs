using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Superficie : MonoBehaviour
{
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
    private void Start()
    {
        StartCoroutine(Fade());
    }

    //IEnumerator Fade()
    //{
    //    for (float f = 1f; f >= 0; f -= 0.01f)
    //    {
    //        Color c = renderer.material.color;
    //        c.a = f;
    //        renderer.material.color = c;
    //        yield return null;
    //    }
    //}
    IEnumerator Fade()
    {
        float f = 1f;
        float delta = 0.01f;
        while (true)
        {
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            f = f - delta;
            if (f <= 0 || f >= 1)
            {
                delta = delta * -1;
            }
            yield return null;
        }
    }
}
