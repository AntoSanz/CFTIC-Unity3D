using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiExplosionScript : MonoBehaviour
{
    private const int TIME_TO_DESTROY = 1;
    void Start()
    {
        Destroy(this.gameObject, TIME_TO_DESTROY);
    }
}
